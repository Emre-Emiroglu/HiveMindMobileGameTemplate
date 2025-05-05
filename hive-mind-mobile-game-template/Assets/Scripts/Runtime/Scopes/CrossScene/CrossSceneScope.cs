using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Controllers.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.CrossScene;
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
        [SerializeField] private CrossSceneSettings crossSceneSettings;
        [SerializeField] private CurrencySettings currencySettings;
        [SerializeField] private LevelSettings levelSettings;
        #endregion

        #region Bindings
        protected override void Configure(IContainerBuilder builder)
        {
            ModelBindings(builder);
            ControllerBindings(builder);
            MediationBindings(builder);
        }
        private void ModelBindings(IContainerBuilder builder)
        {
            builder.RegisterInstance(settings).AsSelf();
            builder.RegisterInstance(crossSceneSettings).AsSelf();
            builder.RegisterInstance(currencySettings).AsSelf();
            builder.RegisterInstance(levelSettings).AsSelf();
            
            builder.Register<SettingsModel>(Lifetime.Singleton).AsSelf();
            builder.Register<CrossSceneModel>(Lifetime.Singleton).AsSelf();
            builder.Register<CurrencyModel>(Lifetime.Singleton).AsSelf();
            builder.Register<LevelModel>(Lifetime.Singleton).AsSelf();
        }
        private void ControllerBindings(IContainerBuilder builder)
        {
            builder.DeclareSignal<ChangeLoadingScreenActivationSignal>();
            builder.DeclareSignal<PlayAudioSignal>();
            builder.DeclareSignal<ChangeCurrencySignal>();
            builder.DeclareSignal<RefreshCurrencyVisualSignal>();
            builder.DeclareSignal<SpawnCurrencyTrailSignal>();
            builder.DeclareSignal<ChangeUIPanelSignal>();
            
            builder.RegisterEntryPoint<AudioController>().AsSelf();
            builder.RegisterEntryPoint<LoadingScreenPanelController>().AsSelf();
            builder.RegisterEntryPoint<CurrencyTrailSpawnController>().AsSelf();
        }
        private void MediationBindings(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<AudioView>();
            builder.RegisterComponentInHierarchy<LoadingScreenPanelView>();
            
            builder.RegisterEntryPoint<AudioMediator>().AsSelf();
            builder.RegisterEntryPoint<LoadingScreenPanelMediator>().AsSelf();
        }
        #endregion
    }
}