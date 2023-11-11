﻿using Microsoft.AspNetCore.Http;
using AvSBookStore.Web.Models;
using System.IO;
using System.Text;

namespace AvSBookStore.Web
{
    public static class SessionExtension
    {
        private const string key = "Cart";

        public static void Set(this ISession session, Cart value)
        {
            if (value == null)
                return;

            using (MemoryStream stream = new MemoryStream())
            using (BinaryWriter writer = new BinaryWriter(stream, Encoding.UTF8, true))
            {
                writer.Write(value.OrderId);
                writer.Write(value.TotalCount);
                writer.Write(value.TotalPrice);

                session.Set(key, stream.ToArray());
            }

        }

        public static bool TryGetCart(this ISession session, out Cart value)
        {
            if (session.TryGetValue(key, out byte[] buffer))
            {
                using (MemoryStream stream = new MemoryStream(buffer))
                using (BinaryReader reader = new BinaryReader(stream, Encoding.UTF8, true))
                {

                    var orderId = reader.ReadInt32();
                    var totalCount = reader.ReadInt32();
                    var totalPrice = reader.ReadDecimal();

                    value = new Cart(orderId)
                    {
                        TotalCount = totalCount,
                        TotalPrice = totalPrice,
                    };

                    return true;
                }
            }

            value = null;

            return false;
        }
    }
}
