using System.Threading.Tasks;

namespace Client.Common.Interfaces
{
    public interface IUnauthorizedHandlerStrategy
    {
        Task ExecuteAsync();
    }
}
