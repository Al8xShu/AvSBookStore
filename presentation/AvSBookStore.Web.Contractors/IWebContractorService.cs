using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AvSBookStore.Web.Contractors
{
    public interface IWebContractorService
    {
        string Name { get; }

        Uri StartSession(IReadOnlyDictionary<string, string> paramenters, Uri returnUri);

        Task<Uri> StartSessionAsync(IReadOnlyDictionary<string, string> paramenters, Uri returnUri);
    }
}
