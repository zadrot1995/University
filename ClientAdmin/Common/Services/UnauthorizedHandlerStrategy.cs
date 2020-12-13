using System.Threading.Tasks;
using Unity;
using ClientAdmin.Common.Interfaces;
using ClientAdmin.ViewModels;

namespace ClientAdmin.Common.Services
{
    public class UnauthorizedHandlerStrategy : IUnauthorizedHandlerStrategy
    {
        public UnauthorizedHandlerStrategy()
        {
        }

        public async Task ExecuteAsync()
        {
            //var navigatorService = ((App)Application.Current).UnityContainer.Resolve<INavigatorService>();
            //await Device.InvokeOnMainThreadAsync(async () =>
            //    await navigatorService.ResetWithNavigationRootAsync<LoginViewModel>());
        }
    }
}
