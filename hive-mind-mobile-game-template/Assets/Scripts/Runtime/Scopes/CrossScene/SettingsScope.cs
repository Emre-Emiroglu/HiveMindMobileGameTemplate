using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Controllers.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Views.CrossScene;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Scopes.CrossScene
{
    public sealed class SettingsScope : LifetimeScope
    {
        #region Fields
        [Header("Settings Scope Fields")]
        [SerializeField] private SettingsView settingsView;
        #endregion
        
        #region Bindings
        protected override void Configure(IContainerBuilder builder)
        {
            ControllerBindings(builder);
            MediationBindings(builder);
        }
        private void ControllerBindings(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<SettingsVerticalGroupController>().AsSelf();
            builder.RegisterEntryPoint<SettingsButtonVisualController>().AsSelf();
            builder.RegisterEntryPoint<SettingsButtonController>().AsSelf();
            builder.RegisterEntryPoint<MainButtonController>().AsSelf();
            builder.RegisterEntryPoint<ExitButtonController>().AsSelf();
        }
        private void MediationBindings(IContainerBuilder builder)
        {
            builder.RegisterInstance(settingsView).AsSelf();
            
            builder.RegisterEntryPoint<SettingsMediator>().AsSelf();
        }
        #endregion
    }
}