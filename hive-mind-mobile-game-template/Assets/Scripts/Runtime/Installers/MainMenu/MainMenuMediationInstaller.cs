using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Views.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Views.MainMenu;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Installers.MainMenu
{
    public sealed class MainMenuMediationInstaller : Installer
    {
        #region Bindings
        public override void InstallBindings()
        {
            Container.Bind<StartPanelView>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.Bind<ShopPanelView>().FromComponentInHierarchy().AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<StartPanelMediator>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<ShopPanelMediator>().AsSingle().NonLazy();

            Container.Install<ViewMediatorInstaller<CurrencyView, CurrencyMediator>>();
            Container.Install<ViewMediatorInstaller<SettingsView, SettingsMediator>>();
        }
        #endregion
    }
}
