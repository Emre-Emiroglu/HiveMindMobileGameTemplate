using HMPersistentData.Runtime;
using HMPool.Runtime;
using HMSignalBus.Runtime;
using HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.Application;
using HiveMindMobileGameTemplate.Runtime.Handlers.Application;
using HiveMindMobileGameTemplate.Runtime.Models.Application;
using HiveMindMobileGameTemplate.Runtime.Signals.Application;
using HiveMindMobileGameTemplate.Runtime.Utilities.Extensions;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace HiveMindMobileGameTemplate.Runtime.Scopes.ApplicationScope
{
    public sealed class ApplicationScope : LifetimeScope
    {
        #region Fields
        [Header("Application Scope Fields")]
        [SerializeField] private ApplicationSettings applicationSettings;
        [SerializeField] private PoolConfig poolConfig;
        #endregion
        
        #region Bindings
        protected override void Configure(IContainerBuilder builder)
        {
            ServiceBindings(builder);
            ModelBindings(builder);
            ControllerBindings(builder);
            HandlerBindings(builder);
        }
        private void ServiceBindings(IContainerBuilder builder)
        {
            PersistentDataServiceUtilities.Initialize();
            
            builder.RegisterSignalBus();
            builder.RegisterPoolService(poolConfig);
        }
        private void ModelBindings(IContainerBuilder builder)
        {
            builder.RegisterInstance(applicationSettings).AsSelf();
            
            builder.Register<ApplicationModel>(Lifetime.Singleton).AsSelf();
        }
        private void ControllerBindings(IContainerBuilder builder)
        {
            builder.DeclareSignal<InitializeApplicationSignal>();
            builder.DeclareSignal<QuitApplicationSignal>();
        }
        private void HandlerBindings(IContainerBuilder builder) =>
            builder.RegisterEntryPoint<ApplicationHandler>().AsSelf();
        #endregion

        #region Cycle
        private void Start() => Container.Resolve<SignalBus>().Fire(new InitializeApplicationSignal());
        #endregion
    }
}