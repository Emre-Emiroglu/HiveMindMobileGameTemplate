using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.MainMenu;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Handlers.MainMenu;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.MainMenu;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.MainMenu;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Utilities.Extensions;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Views.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Views.MainMenu;
using CodeCatGames.HMSignalBus.Runtime;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Scopes.MainMenu
{
    public sealed class MainMenuScope : LifetimeScope
    {
        #region Fields
        [Header("Main Menu Scope Fields")]
        [SerializeField] private MainMenuSettings mainMenuSettings;
        #endregion
        
        #region Bindings
        protected override void Configure(IContainerBuilder builder)
        {
            ModelBindings(builder);
            ControllerBindings(builder);
            MediationBindings(builder);
            HandlerBindings(builder);
        }
        private void ModelBindings(IContainerBuilder builder)
        {
            builder.RegisterInstance(mainMenuSettings).AsSelf();

            builder.Register<MainMenuModel>(Lifetime.Singleton).AsSelf();
        }
        private void ControllerBindings(IContainerBuilder builder) => builder.DeclareSignal<InitializeMainMenuSignal>();
        private void MediationBindings(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<StartPanelView>().AsSelf();
            builder.RegisterComponentInHierarchy<ShopPanelView>().AsSelf();
            builder.RegisterComponentInHierarchy<CurrencyView>();
            builder.RegisterComponentInHierarchy<SettingsView>();
            
            builder.RegisterEntryPoint<StartPanelMediator>().AsSelf();
            builder.RegisterEntryPoint<ShopPanelMediator>().AsSelf();
            builder.RegisterEntryPoint<CurrencyMediator>().AsSelf();
            builder.RegisterEntryPoint<SettingsMediator>().AsSelf();
        }
        private void HandlerBindings(IContainerBuilder builder) =>
            builder.RegisterEntryPoint<MainMenuHandler>().AsSelf();
        #endregion

        #region Cycle
        private void Start() => Container.Resolve<SignalBus>().Fire(new InitializeMainMenuSignal());
        #endregion
    }
}