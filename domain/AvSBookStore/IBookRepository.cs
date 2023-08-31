using System;
using System.Collections.Generic;
using System.Text;

namespace AvSBookStore
{
    public interface IBookRepository
    {
        Book[] getAllByTitle(string titlePart);
    }
}
