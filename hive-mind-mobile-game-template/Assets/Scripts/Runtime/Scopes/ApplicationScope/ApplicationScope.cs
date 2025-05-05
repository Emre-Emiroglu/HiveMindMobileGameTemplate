using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Controllers.Application;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.Application;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.Application;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.Application;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Utilities.Extensions;
using CodeCatGames.HMPersistentData.Runtime;
using CodeCatGames.HMPool.Runtime;
using CodeCatGames.HMSignalBus.Runtime;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Scopes.ApplicationScope
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
            
            builder.RegisterEntryPoint<InitializeApplicationController>().AsSelf();
            builder.RegisterEntryPoint<QuitApplicationController>().AsSelf();
        }
        #endregion

        #region Cycle
        private void Start() => Container.Resolve<SignalBus>().Fire(new InitializeApplicationSignal());
        #endregion
    }
}