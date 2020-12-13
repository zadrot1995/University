using System.Net.Http;
using System.Threading.Tasks;
using ClientAdmin.Models;

namespace ClientAdmin.Common.Interfaces
{
    public interface IResponseProcessor
    {
        Task<Result<T>> GetResponseAsync<T>(HttpResponseMessage httpResponse);
    }
}
