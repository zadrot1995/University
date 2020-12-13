using System;
using System.Linq;
using System.Windows.Controls;
using Flagman.Common.Services;
using Prism.Ioc;
using Prism.Mvvm;

namespace Client.Common.Extensions
{
    public static class NavigationExtension
    {
        public static void RegisterTypeForViewModelNavigation<TView, TViewModel>(this IContainerRegistry container) where TView : Page where TViewModel : class
        {
            var viewType = typeof(TView);
            ViewModelLocationProvider.Register(viewType.ToString(), typeof(TViewModel));
            container.RegisterForNavigation<TView>(typeof(TViewModel).Name);
        }

        public static void RegisterHintTypeForViewModelNavigation<TView, TViewModel>(this IContainerRegistry container) where TView : Page where TViewModel : class
        {
            var viewType = typeof(TView);
            ViewModelLocationProvider.Register(viewType.ToString(), typeof(TViewModel));
            //HintService.RegisterHint(typeof(TViewModel));
            container.RegisterForNavigation<TView>(typeof(TViewModel).Name);
        }

        public static string CreateNavigationUrl(params Type[] types)
        {
            var url = string.Join("/", types.Select(t => t.Name));
            return $"/{url}";
        }
    }
}
