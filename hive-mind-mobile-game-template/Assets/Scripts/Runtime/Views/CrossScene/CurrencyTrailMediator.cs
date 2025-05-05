using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Controllers.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.CrossScene;
using CodeCatGames.HMModelViewController.Runtime;
using VContainer.Unity;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Views.CrossScene
{
    public sealed class CurrencyTrailMediator : Mediator<CurrencyModel, CurrencySettings, CurrencyTrailView>, IInitializable
    {
        #region ReadonlyFields
        private readonly CurrencyTrailVisualController _currencyTrailVisualController;
        private readonly CurrencyTrailTweenController _currencyTrailTweenController;
        #endregion

        #region Constructor
        public CurrencyTrailMediator(CurrencyModel model, CurrencyTrailView view,
            CurrencyTrailVisualController currencyTrailVisualController,
            CurrencyTrailTweenController currencyTrailTweenController) : base(model, view)
        {
            _currencyTrailVisualController = currencyTrailVisualController;
            _currencyTrailTweenController = currencyTrailTweenController;
        }
        #endregion

        #region Core
        void IInitializable.Initialize() => base.Initialize();
        public override void SetSubscriptions(bool isSubscribed)
        {
            if (isSubscribed)
            {
                View.Created += OnCreated;
                View.GetFromPool += OnGetFromPool;
                View.ReturnToPool += OnReturnToPool;
                View.Destroyed += OnDestroyed;
            }
            else
            {
                View.Created -= OnCreated;
                View.GetFromPool -= OnGetFromPool;
                View.ReturnToPool -= OnReturnToPool;
                View.Destroyed -= OnDestroyed;
            }
        }
        #endregion

        #region PoolReceivers
        private void OnCreated() { }
        private void OnGetFromPool()
        {
            _currencyTrailVisualController.Execute();
            _currencyTrailTweenController.Execute();
        }
        private void OnReturnToPool() { }
        private void OnDestroyed() { }
        #endregion
    }
}