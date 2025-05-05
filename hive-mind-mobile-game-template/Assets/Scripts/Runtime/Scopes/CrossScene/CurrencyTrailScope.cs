using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Controllers.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Views.CrossScene;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Scopes.CrossScene
{
    public sealed class CurrencyTrailScope : LifetimeScope
    {
        #region Fields
        [Header("Currency Trail Scope Fields")]
        [SerializeField] private CurrencyTrailView currencyTrailView;
        #endregion
        
        #region Bindings
        protected override void Configure(IContainerBuilder builder)
        {
            ControllerBindings(builder);
            MediationBindings(builder);
        }
        private void ControllerBindings(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<CurrencyTrailVisualController>().AsSelf();
            builder.RegisterEntryPoint<CurrencyTrailTweenController>().AsSelf();
        }
        private void MediationBindings(IContainerBuilder builder)
        {
            builder.RegisterInstance(currencyTrailView).AsSelf();
            builder.RegisterEntryPoint<CurrencyTrailMediator>().AsSelf();
        }
        #endregion
    }
}