using System.Threading.Tasks;

namespace ClientAdmin.Common.Interfaces
{
    public interface IUnauthorizedHandlerStrategy
    {
        Task ExecuteAsync();
    }
}
