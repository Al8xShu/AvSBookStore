using Microsoft.AspNetCore.Http;
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
                writer.Write(value.Items.Count);

                foreach (var item in value.Items)
                {
                    writer.Write(item.Key);
                    writer.Write(item.Value);
                }

                writer.Write(value.Amount);

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
                    value = new Cart();

                    var lenght = reader.ReadInt32();
                    for (int i = 0; i < lenght; i++)
                    {
                        var bookId = reader.ReadInt32();
                        var count = reader.ReadInt32();

                        value.Items.Add(bookId, count);
                    }

                    value.Amount = reader.ReadDecimal();

                    return true;
                }
            }

            value = null;

            return false;
        }
    }
}
