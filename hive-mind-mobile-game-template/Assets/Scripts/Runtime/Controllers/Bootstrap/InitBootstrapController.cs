using System;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Enums.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.Bootstrap;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.Bootstrap;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.CrossScene;
using CodeCatGames.HMSignalBus.Runtime;
using Cysharp.Threading.Tasks;
using VContainer.Unity;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Controllers.Bootstrap
{
    public sealed class InitBootstrapController : IInitializable, IDisposable
    {
        #region ReadonlyFields
        private readonly SignalBus _signalBus;
        private readonly BootstrapModel _bootstrapModel;
        #endregion

        #region Constructor
        public InitBootstrapController(SignalBus signalBus, BootstrapModel bootstrapModel)
        {
            _signalBus = signalBus;
            _bootstrapModel = bootstrapModel;
        }
        #endregion

        #region Core
        public void Initialize() => _signalBus.Subscribe<InitBootstrapSignal>(OnInitBootstrapSignal);
        public void Dispose() => _signalBus.Unsubscribe<InitBootstrapSignal>(OnInitBootstrapSignal);
        #endregion

        #region SignalReceivers
        private void OnInitBootstrapSignal(InitBootstrapSignal signal) => Execute().Forget();
        #endregion

        #region Executes
        private async UniTaskVoid Execute()
        {
            int millisecondsDelay = (int)(_bootstrapModel.Settings.SceneActivationDuration * 1000f);
            
            await UniTask.Delay(millisecondsDelay);

            _signalBus.Fire(new LoadSceneSignal(SceneID.MainMenu));
        }
        #endregion
    }
}
