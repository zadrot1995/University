using System.Threading;
using System.Threading.Tasks;

namespace Client.Common.Interfaces
{
    public interface IHttpService
    {
        Task<Result<T>> GetAsync<T>(string requestUri, string baseUrl = null, CancellationToken cancellationToken = default, IResponseProcessor responseProcessor = null, bool withRetry = true);
        Task<Result<T>> PostAsync<T>(string requestUri, object model, string baseUrl = null, CancellationToken cancellationToken = default,
            IResponseProcessor responseProcessor = null, bool withRetry = true, IRequestProcessor requestProcessor = null);
        Task<Result<T>> PutAsync<T>(string requestUri, object model, string baseUrl = null, CancellationToken cancellationToken = default,
            IResponseProcessor responseProcessor = null, bool withRetry = true, IRequestProcessor requestProcessor = null);
        Task<Result<T>> DeleteAsync<T>(string requestUri, string baseUrl = null, CancellationToken cancellationToken = default, IResponseProcessor responseProcessor = null, bool withRetry = true);
    }
}
