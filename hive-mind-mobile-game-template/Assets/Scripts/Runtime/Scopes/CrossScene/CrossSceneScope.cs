using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Views.CrossScene;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using AudioSettings = CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.CrossScene.AudioSettings;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Scopes.CrossScene
{
    public sealed class CrossSceneScope : LifetimeScope
    {
        #region Fields
        [Header("Cross Scene Scope Fields")]
        [SerializeField] private CrossSceneSettings crossSceneSettings;
        [SerializeField] private CurrencySettings currencySettings;
        [SerializeField] private LevelSettings levelSettings;
        [SerializeField] private AudioSettings audioSettings;
        #endregion

        #region Bindings
        protected override void Configure(IContainerBuilder builder)
        {
            ModelBindings(builder);
            MediationBindings(builder);
            ControllerBindings(builder);
        }
        private void ModelBindings(IContainerBuilder builder)
        {
            builder.RegisterInstance(crossSceneSettings).AsSelf();
            builder.RegisterInstance(currencySettings).AsSelf();
            builder.RegisterInstance(levelSettings).AsSelf();
            builder.RegisterInstance(audioSettings).AsSelf();
            
            builder.Register<CrossSceneModel>(Lifetime.Singleton).AsSelf();
            builder.Register<CurrencyModel>(Lifetime.Singleton).AsSelf();
            builder.Register<LevelModel>(Lifetime.Singleton).AsSelf();
            builder.Register<AudioModel>(Lifetime.Singleton).AsSelf();
        }
        private void MediationBindings(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<CurrencyView>();
            builder.RegisterComponentInHierarchy<LoadingScreenPanelView>();
            builder.RegisterComponentInHierarchy<AudioView>();
            builder.RegisterComponentInHierarchy<SettingsView>();

            builder.RegisterEntryPoint<CurrencyMediator>().AsSelf();
            builder.RegisterEntryPoint<LoadingScreenPanelMediator>().AsSelf();
            builder.RegisterEntryPoint<AudioMediator>().AsSelf();
            builder.RegisterEntryPoint<SettingsMediator>().AsSelf();
        }
        private void ControllerBindings(IContainerBuilder builder)
        {
        }
        #endregion
    }
}