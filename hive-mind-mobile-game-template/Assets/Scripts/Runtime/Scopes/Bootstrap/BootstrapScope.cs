using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Controllers.Bootstrap;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.Bootstrap;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.Bootstrap;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.Bootstrap;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Utilities.Extensions;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Views.Bootstrap;
using CodeCatGames.HMSignalBus.Runtime;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Scopes.Bootstrap
{
    public sealed class BootstrapScope : LifetimeScope
    {
        #region Fields
        [Header("Bootstrap Scope Fields")]
        [SerializeField] private BootstrapSettings bootstrapSettings;
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
            builder.RegisterInstance(bootstrapSettings).AsSelf();

            builder.Register<BootstrapModel>(Lifetime.Singleton).AsSelf();
        }
        private void MediationBindings(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<LogoHolderPanelView>().AsSelf();

            builder.RegisterEntryPoint<LogoHolderPanelMediator>().AsSelf();
        }
        private void ControllerBindings(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<InitBootstrapController>().AsSelf();

            builder.DeclareSignal<InitBootstrapSignal>();
        }
        #endregion

        #region Cycle
        private void Start() => Container.Resolve<SignalBus>().Fire(new InitBootstrapSignal());
        #endregion
    }
}