using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.MainMenu;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Utilities.Extensions;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Views.MainMenu;
using CodeCatGames.HMSignalBus.Runtime;
using VContainer;
using VContainer.Unity;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Scopes.MainMenu
{
    public sealed class MainMenuScope : LifetimeScope
    {
        #region Bindings
        protected override void Configure(IContainerBuilder builder)
        {
            ControllerBindings(builder);
            MediationBindings(builder);
        }
        private void ControllerBindings(IContainerBuilder builder) => builder.DeclareSignal<InitializeMainMenuSignal>();
        private void MediationBindings(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<StartPanelView>().AsSelf();
            builder.RegisterComponentInHierarchy<ShopPanelView>().AsSelf();
            
            builder.RegisterEntryPoint<StartPanelMediator>().AsSelf();
            builder.RegisterEntryPoint<ShopPanelMediator>().AsSelf();
        }
        #endregion

        #region Cycle
        private void Start() => Container.Resolve<SignalBus>().Fire(new InitializeMainMenuSignal());
        #endregion
    }
}