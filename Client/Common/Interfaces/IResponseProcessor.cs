using System.Net.Http;
using System.Threading.Tasks;
using Flagman.Models;

namespace Client.Common.Interfaces
{
    public interface IResponseProcessor
    {
        Task<Result<T>> GetResponseAsync<T>(HttpResponseMessage httpResponse);
    }
}
