using HiveMindMobileGameTemplate.Runtime.Controllers.CrossScene;
using HiveMindMobileGameTemplate.Runtime.Views.CrossScene;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace HiveMindMobileGameTemplate.Runtime.Scopes.CrossScene
{
    public sealed class CurrencyScope : LifetimeScope
    {
        #region Fields
        [Header("Currency Scope Fields")]
        [SerializeField] private CurrencyView currencyView;
        #endregion
        
        #region Bindings
        protected override void Configure(IContainerBuilder builder)
        {
            ControllerBindings(builder);
            MediationBindings(builder);
        }
        private void ControllerBindings(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<CurrencyDisplayController>().AsSelf();
            builder.RegisterEntryPoint<CurrencyButtonController>().AsSelf();
        }
        private void MediationBindings(IContainerBuilder builder)
        {
            builder.RegisterInstance(currencyView).AsSelf();
            
            builder.RegisterEntryPoint<CurrencyMediator>().AsSelf();
        }
        #endregion
    }
}