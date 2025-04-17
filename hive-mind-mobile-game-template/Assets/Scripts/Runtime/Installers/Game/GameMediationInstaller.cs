using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Views.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Views.Game;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Installers.Game
{
    public sealed class GameMediationInstaller : Installer
    {
        #region Bindings
        public override void InstallBindings()
        {
            Container.Bind<GameOverPanelView>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.Bind<InGamePanelView>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.Bind<TutorialPanelView>().FromComponentInHierarchy().AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<GameOverPanelMediator>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<InGamePanelMediator>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<TutorialPanelMediator>().AsSingle().NonLazy();

            Container.Install<ViewMediatorInstaller<CurrencyView, CurrencyMediator>>();
            Container.Install<ViewMediatorInstaller<SettingsView, SettingsMediator>>();
        }
        #endregion
    }
}
