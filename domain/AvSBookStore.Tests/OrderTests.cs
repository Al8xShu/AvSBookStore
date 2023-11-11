using System;
using Xunit;

namespace AvSBookStore.Tests
{
    public class OrderTests
    {
        [Fact]
        public void OrderWithNullItemsThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            new Order(1, null));
        }

        [Fact]
        public void TotalCountWithEmptyItemsReturnZero()
        {
            Order order = new Order(1, new OrderItem[0]);
            Assert.Equal(0, order.TotalCount);
        }

        [Fact]
        public void TotalPriceWithEmptyItemsReturnZero()
        {
            Order order = new Order(1, new OrderItem[0]);
            Assert.Equal(0m, order.TotalCount);
        }

        [Fact]
        public void TotalCountWithNonEmptyItemsCalculateTotalCount()
        {
            Order order = new Order(1, new[]
            {
                new OrderItem(1, 3, 10m),
                new OrderItem(2, 5, 100m),
            });

            Assert.Equal(3 + 5, order.TotalCount);
        }

        [Fact]
        public void TotalPriceWithNonEmptyItemsCalculateTotalPrice()
        {
            Order order = new Order(1, new[]
            {
                new OrderItem(1, 3, 10m),
                new OrderItem(2, 5, 100m),
            });

            Assert.Equal(3 * 10m + 5 * 100m, order.TotalPrice);
        }
    }
}
