using AuthWithJwt.ViewModels;
using AuthWithJwt.Views;
using Prism.Ioc;
using Prism.Modularity;

namespace AuthWithJwt
{
    public class AuthWithJwtModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ViewA, ViewAViewModel>();
        }
    }
}
