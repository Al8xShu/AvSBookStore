using System;
using System.Collections.Generic;

namespace AvSBookStore.Web.Contractors
{
    public interface IWebContractorService
    {
        string Name { get; }

        Uri StartSession(IReadOnlyDictionary<string, string> paramenters, Uri returnUri);
    }
}
