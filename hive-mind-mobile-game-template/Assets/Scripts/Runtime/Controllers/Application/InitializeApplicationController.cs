using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.Application;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.Application;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Temp;
using CodeCatGames.HMSignalBus.Runtime;
using UnityEngine;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Controllers.Application
{
    public sealed class InitializeApplicationController : SignalListener
    {
        #region ReadonlyFields
        private readonly ApplicationModel _applicationModel;
        #endregion
        
        #region Constructor
        public InitializeApplicationController(SignalBus signalBus, ApplicationModel applicationModel) :
            base(signalBus) => _applicationModel = applicationModel;
        #endregion

        #region Core
        protected override void SetSubscriptions(bool isSubscribed)
        {
            if (isSubscribed)
                SignalBus.Subscribe<InitializeApplicationSignal>(OnInitializeApplicationSignal);
            else
                SignalBus.Unsubscribe<InitializeApplicationSignal>(OnInitializeApplicationSignal);
        }
        #endregion

        #region SignalReceivers
        private void OnInitializeApplicationSignal(InitializeApplicationSignal signal) => InitializeApplication();
        #endregion

        #region Executes
        private void InitializeApplication()
        {
            UnityEngine.Application.targetFrameRate = _applicationModel.Settings.TargetFrameRate;
            UnityEngine.Application.runInBackground = _applicationModel.Settings.RunInBackground;

            Screen.sleepTimeout = SleepTimeout.NeverSleep;
        }
        #endregion
    }
}