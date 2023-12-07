﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace AvSBookStore
{
    public class OrderItemCollection : IReadOnlyCollection<OrderItem>
    {
        private readonly List<OrderItem> items;

        public OrderItemCollection(IEnumerable<OrderItem> items)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            this.items = new List<OrderItem>(items);
        }

        public int Count => items.Count;

        public OrderItem Get(int bookId)
        {
            if (TryGet(bookId, out OrderItem orderItem))
            {
                return orderItem;
            }
            throw new InvalidOperationException("Book not found!");
        }

        public bool TryGet(int bookId, out OrderItem orderItem)
        {
            var index = items.FindIndex(item => item.BookId == bookId);

            if (index == -1)
            {
                orderItem = null;

                return false;
            }

            orderItem = items[index];

            return true;
        }

        public OrderItem Add(int bookId, decimal price, int count)
        {
            if (TryGet(bookId, out OrderItem orderItem))
            {
                throw new InvalidOperationException("Book is already exist!");
            }

            orderItem = new OrderItem(bookId, count, price);
            items.Add(orderItem);

            return orderItem;
        }

        public void Remove(int bookId)
        {
            items.Remove(Get(bookId));
        }

        public IEnumerator<OrderItem> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (items as IEnumerable).GetEnumerator();
        }
    }
}
