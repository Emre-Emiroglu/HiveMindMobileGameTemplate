using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Temp;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Views.CrossScene;
using CodeCatGames.HMPool.Runtime;
using CodeCatGames.HMSignalBus.Runtime;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Controllers.CrossScene
{
    public sealed class CurrencyTrailSpawnController : SignalListener
    {
        #region ReadonlyFields
        private readonly PoolService _poolService;
        #endregion

        #region Constructor
        public CurrencyTrailSpawnController(SignalBus signalBus, PoolService poolService) : base(signalBus) =>
            _poolService = poolService;
        #endregion

        #region Core
        protected override void SetSubscriptions(bool isSubscribed)
        {
            if (isSubscribed)
                SignalBus.Subscribe<SpawnCurrencyTrailSignal>(OnSpawnCurrencyTrailSignal);
            else
                SignalBus.Unsubscribe<SpawnCurrencyTrailSignal>(OnSpawnCurrencyTrailSignal);
        }
        #endregion

        #region SignalReceivers
        private void OnSpawnCurrencyTrailSignal(SpawnCurrencyTrailSignal signal) => SpawnACurrencyTrail(signal);
        #endregion

        #region Executes
        private void SpawnACurrencyTrail(SpawnCurrencyTrailSignal signal)
        {
            CurrencyTrailView view = _poolService.GetMono<CurrencyTrailView>();
            
            view.CurrencyTrailData = signal.CurrencyTrailData;
        }
        #endregion
    }
}