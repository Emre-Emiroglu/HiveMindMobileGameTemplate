using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ValueObjects.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Views.CrossScene;
using CodeCatGames.HMModelViewController.Runtime;
using CodeCatGames.HMPool.Runtime;
using CodeCatGames.HMSignalBus.Runtime;
using PrimeTween;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Controllers.CrossScene
{
    public sealed class CurrencyTrailTweenController : Controller<CurrencyModel, CurrencySettings, CurrencyTrailView>
    {
        #region ReadonlyFields
        private readonly SignalBus _signalBus;
        private readonly PoolService _poolService;
        #endregion
        
        #region Constructor
        public CurrencyTrailTweenController(CurrencyModel model, CurrencyTrailView view, SignalBus signalBus,
            PoolService poolService) : base(model, view)
        {
            _signalBus = signalBus;
            _poolService = poolService;
        }
        #endregion

        #region Executes
        public override void Execute(params object[] parameters)
        {
            CurrencyTrailData data = View.CurrencyTrailData;

            Tween.Position(View.transform, data.TargetPosition, data.Duration, data.Ease)
                .OnComplete(() => TweenCompleteCallback(data));
        }
        private void TweenCompleteCallback(CurrencyTrailData data)
        {
            _signalBus.Fire(new ChangeCurrencySignal(data.CurrencyType, data.Amount, false));
            
            _poolService.ReleaseMono(View);
        }
        #endregion
    }
}