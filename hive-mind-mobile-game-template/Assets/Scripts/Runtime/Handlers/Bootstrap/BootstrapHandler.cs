using HMSignalBus.Runtime;
using Cysharp.Threading.Tasks;
using HiveMindMobileGameTemplate.Runtime.Enums.CrossScene;
using HiveMindMobileGameTemplate.Runtime.Models.Bootstrap;
using HiveMindMobileGameTemplate.Runtime.Signals.Bootstrap;
using HiveMindMobileGameTemplate.Runtime.Signals.CrossScene;
using HiveMindMobileGameTemplate.Runtime.Temp;

namespace HiveMindMobileGameTemplate.Runtime.Handlers.Bootstrap
{
    public sealed class BootstrapHandler : SignalListener
    {
        #region ReadonlyFields
        private readonly BootstrapModel _bootstrapModel;
        #endregion

        #region Constructor
        public BootstrapHandler(SignalBus signalBus, BootstrapModel bootstrapModel) : base(signalBus) =>
            _bootstrapModel = bootstrapModel;
        #endregion

        #region Core
        protected override void SetSubscriptions(bool isSubscribed)
        {
            if (isSubscribed)
                SignalBus.Subscribe<InitializeBootstrapSignal>(OnInitializeBootstrapSignal);
            else
                SignalBus.Unsubscribe<InitializeBootstrapSignal>(OnInitializeBootstrapSignal);
        }
        #endregion

        #region SignalReceivers
        private void OnInitializeBootstrapSignal(InitializeBootstrapSignal signal) => InitializeBootstrap().Forget();
        #endregion
        
        #region Executes
        private async UniTaskVoid InitializeBootstrap()
        {
            int millisecondsDelay = (int)(_bootstrapModel.Settings.SceneActivationDuration * 1000f);
            
            await UniTask.Delay(millisecondsDelay);
            
            SignalBus.Fire(new LoadSceneSignal(SceneID.MainMenu));
        }
        #endregion
    }
}