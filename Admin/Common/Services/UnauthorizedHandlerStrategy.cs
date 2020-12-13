using System.Threading.Tasks;
using Unity;
using Client.Common.Interfaces;
using Client.ViewModels;

namespace ViClinic.Common.Services
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
