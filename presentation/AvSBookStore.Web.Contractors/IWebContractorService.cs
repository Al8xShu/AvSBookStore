using System;

namespace AvSBookStore.Web.Contractors
{
    public interface IWebContractorService
    {
        string UniqCode { get; }

        string GetUri { get; }
    }
}
