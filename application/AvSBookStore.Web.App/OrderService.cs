﻿using Microsoft.AspNetCore.Http;
using AvSBookStore.Messages;
using System.Linq;
using System.Collections.Generic;
using System;
using PhoneNumbers;
using System.Threading.Tasks;

namespace AvSBookStore.Web.App
{
    public class OrderService
    {
        private readonly IBookRepository bookRepository;
        private readonly IOrderRepository orderRepository;
        private readonly INotificationService notificationService;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly PhoneNumberUtil phoneNumberUtil = PhoneNumberUtil.GetInstance();

        protected ISession Session => httpContextAccessor.HttpContext.Session;

        public OrderService(IBookRepository bookRepository,
            IOrderRepository orderRepository,
            INotificationService notificationService,
            IHttpContextAccessor httpContextAccessor)
        {

            this.bookRepository = bookRepository;
            this.orderRepository = orderRepository;
            this.notificationService = notificationService;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<(bool hasValue, OrderModel model)> TryGetModel()
        {
            var (hasValue, order) = await TryGetOrderAsync();

            if (hasValue)
            {
                return (true, await Map(order));
            }

            return (false, null);
        }

        public async Task<(bool hasValue, OrderModel model)> TryGetModelAsync()
        {
            var(hasValue, order) = await TryGetOrderAsync();

            if (hasValue)
            {
                return (true, await Map(order));
            }

            return (false, null);
        }

        internal async Task<(bool hasValue, Order order)> TryGetOrderAsync()
        {
            if (Session.TryGetCart(out Cart cart))
            {
                var order = await orderRepository.GetByIdAsync(cart.OrderId);
                return (true, order);
            }

            return (false, null);
        }

        private async Task<OrderModel> Map(Order order)
        {
            var books = await GetBooks(order);
            var items = from item in order.Items
                        join book in books on item.BookId equals book.Id
                        select new OrderItemModel()
                        {
                            BookId = book.Id,
                            Title = book.Title,
                            Author = book.Author,
                            Price = item.Price,
                            Count = item.Count
                        };

            return new OrderModel()
            {
                Id = order.Id,
                Items = items.ToArray(),
                TotalCount = order.TotalCount,
                TotalPrice = order.TotalPrice,
                CellPhone = order.CellPhone,
                DeliveryDescription = order.Delivery?.Description,
                PaymentDescription = order.Payment?.Description
            };
        }

        private async Task<IEnumerable<Book>> GetBooks(Order order)
        {
            var bookIds = order.Items.Select(item => item.BookId);

            return await bookRepository.GetAllByIdsAsync(bookIds);
        }

        public async Task<OrderModel> AppBookAsync(int bookId, int count)
        {
            if (count < 1)
            {
                throw new InvalidOperationException("Too few books to add!");
            }

            var (hasValue, order) = await TryGetOrderAsync();

            if (!hasValue)
            {
                order = await orderRepository.CreateAsync();
            }

            await AddOrUpdateBookAsync(order, bookId, count);
            UpdateSession(order);

            return await Map(order);
        }

        internal async Task AddOrUpdateBookAsync(Order order, int bookId, int count)
        {
            var book = await bookRepository.GetByIdAsync(bookId);

            if (order.Items.TryGet(bookId, out OrderItem orderItem))
            {
                orderItem.Count += count;
            }
            else
            {
                order.Items.Add(book.Id, book.Price, count);
            }

            await orderRepository.UpdateAsync(order);
        }

        private void UpdateSession(Order order)
        {
            var cart = new Cart(order.Id, order.TotalCount, order.TotalPrice);
            Session.Set(cart);
        }

        public async Task<OrderModel> UpdateBook(int bookId, int count)
        {
            var order = await GetOrderAsync();
            order.Items.Get(bookId).Count = count;

            await orderRepository.UpdateAsync(order);
            UpdateSession(order);

            return await Map(order);
        }

        public async Task<OrderModel> UpdateBookAsync(int bookId, int count)
        {
            var order = await GetOrderAsync();
            order.Items.Get(bookId).Count = count;

            await orderRepository.UpdateAsync(order);
            UpdateSession(order);

            return await Map(order);
        }

        public async Task<OrderModel> RemoveBook(int bookId)
        {
            var order = await GetOrderAsync();
            order.Items.Remove(bookId);

            await orderRepository.UpdateAsync(order);
            UpdateSession(order);

            return await Map(order);
        }

        public async Task<OrderModel> RemoveBookAsync(int bookId)
        {
            var order = await GetOrderAsync();
            order.Items.Remove(bookId);

            await orderRepository.UpdateAsync(order);
            UpdateSession(order);

            return await Map(order);
        }

        public async Task<Order> GetOrderAsync()
        {
            var (hasValue, order) = await TryGetOrderAsync();

            if (hasValue)
            {
                return order;
            }

            throw new InvalidOperationException("Empty session!");
        }

        public async Task<OrderModel> SendConfirmation(string cellPhone)
        {
            var order = await GetOrderAsync();
            var model = await Map(order);

            if (TryFormatPhone(cellPhone, out string formattedPhone))
            {
                var confirmationCode = 1111;

                model.CellPhone = formattedPhone;
                Session.SetInt32(formattedPhone, confirmationCode);

                notificationService.SendConfirmationCode(formattedPhone, confirmationCode);
            }
            else
            {
                model.Errors["CellPhone"] = "The number of phone isn't correct!";
            }

            return model;
        }

        public async Task<OrderModel> SendConfirmationAsync(string cellPhone)
        {
            var order = await GetOrderAsync();
            var model = await Map(order);

            if (TryFormatPhone(cellPhone, out string formattedPhone))
            {
                var confirmationCode = 1111;

                model.CellPhone = formattedPhone;
                Session.SetInt32(formattedPhone, confirmationCode);

                await notificationService.SendConfirmationCodeAsync(formattedPhone, confirmationCode);
            }
            else
            {
                model.Errors["CellPhone"] = "The number of phone isn't correct!";
            }

            return model;
        }

        internal bool TryFormatPhone(string cellPhone, out string formattedPhone)
        {
            try
            {
                var phoneNumber = phoneNumberUtil.Parse(cellPhone, "ru");
                formattedPhone = phoneNumberUtil.Format(phoneNumber, PhoneNumberFormat.INTERNATIONAL);

                    return true;
            }
            catch (NumberParseException)
            {
                formattedPhone = null;

                return false;
            }
        }

        public async Task<OrderModel> ConfirmCellPhone(string cellPhone, int confirmationCode)
        {
            int? storedCode = Session.GetInt32(cellPhone);
            var model = new OrderModel();

            if (storedCode == null)
            {
                model.Errors["cellPhone"] = "Something went wrong. Try again to get the code!";
                return model;
            }

            if (storedCode != confirmationCode)
            {
                model.Errors["cellPhone"] = "Code is incorrect. Chek and try again!";
                return model;
            }

            var order = await GetOrderAsync();
            order.CellPhone = cellPhone;
            await orderRepository.UpdateAsync(order);

            Session.Remove(cellPhone);

            return await Map(order);
        }

        public async Task<OrderModel> SetDelivery(OrderDelivery delivery)
        {
            var order = await GetOrderAsync();
            order.Delivery = delivery;
            await orderRepository.UpdateAsync(order);

            return await Map(order);
        }

        public async Task<OrderModel> SetDeliveryAsync(OrderDelivery delivery)
        {
            var order = await GetOrderAsync();
            order.Delivery = delivery;
            await orderRepository.UpdateAsync(order);

            return await Map(order);
        }

        public async Task<OrderModel> SetPayment(OrderPayment payment)
        {
            var order = await GetOrderAsync();
            order.Payment = payment;
            await orderRepository.UpdateAsync(order);
            Session.RemoveCart();

            await notificationService.StartProcessAsync(order);

            return await Map(order);
        }

        public async Task<OrderModel> SetPaymentAsync(OrderPayment payment)
        {
            var order = await GetOrderAsync();
            order.Payment = payment;
            await orderRepository.UpdateAsync(order);
            Session.RemoveCart();

            await  notificationService.StartProcessAsync(order);

            return await Map(order);
        }
    }
}
