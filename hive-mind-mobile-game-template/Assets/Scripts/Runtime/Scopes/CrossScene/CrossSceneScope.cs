using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Handlers.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Utilities.Extensions;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Views.CrossScene;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Scopes.CrossScene
{
    public sealed class CrossSceneScope : LifetimeScope
    {
        #region Fields
        [Header("Cross Scene Scope Fields")]
        [SerializeField] private Settings settings;
        [SerializeField] private CurrencySettings currencySettings;
        [SerializeField] private LevelSettings levelSettings;
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
            builder.RegisterInstance(settings).AsSelf();
            builder.RegisterInstance(currencySettings).AsSelf();
            builder.RegisterInstance(levelSettings).AsSelf();
            
            builder.Register<SettingsModel>(Lifetime.Singleton).AsSelf();
            builder.Register<CurrencyModel>(Lifetime.Singleton).AsSelf();
            builder.Register<LevelModel>(Lifetime.Singleton).AsSelf();
        }
        private void ControllerBindings(IContainerBuilder builder)
        {
            builder.DeclareSignal<LoadSceneSignal>();
            builder.DeclareSignal<PlayAudioSignal>();
            builder.DeclareSignal<ChangeCurrencySignal>();
            builder.DeclareSignal<RefreshCurrencyVisualSignal>();
            builder.DeclareSignal<ChangeUIPanelSignal>();
        }
        private void MediationBindings(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<AudioView>();
            builder.RegisterComponentInHierarchy<CurrencyView>();
            builder.RegisterComponentInHierarchy<SettingsView>();
            
            builder.RegisterEntryPoint<AudioMediator>().AsSelf();
            builder.RegisterEntryPoint<CurrencyMediator>().AsSelf();
            builder.RegisterEntryPoint<SettingsMediator>().AsSelf();
        }
        private void HandlerBindings(IContainerBuilder builder) =>
            builder.RegisterEntryPoint<CrossSceneHandler>().AsSelf();
        #endregion
    }
}