using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvSbookStore.Web.Contractors
{
    public interface IWebContractorService
    {
        string Name { get; }

        Uri StartSession(IReadOnlyDictionary<string, string> parameters, Uri returnUri);

        Task<Uri> StartSessionAsync(IReadOnlyDictionary<string, string> parameters, Uri returnUri);
    }
}
