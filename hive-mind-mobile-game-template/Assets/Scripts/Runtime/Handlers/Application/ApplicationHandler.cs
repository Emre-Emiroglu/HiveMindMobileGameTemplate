using HMSignalBus.Runtime;
using HiveMindMobileGameTemplate.Runtime.Models.Application;
using HiveMindMobileGameTemplate.Runtime.Signals.Application;
using HiveMindMobileGameTemplate.Runtime.Temp;
using UnityEditor;
using UnityEngine;

namespace HiveMindMobileGameTemplate.Runtime.Handlers.Application
{
    public sealed class ApplicationHandler : SignalListener
    {
        #region ReadonlyFields
        private readonly ApplicationModel _applicationModel;
        #endregion

        #region Constructor
        public ApplicationHandler(SignalBus signalBus, ApplicationModel applicationModel) : base(signalBus) =>
            _applicationModel = applicationModel;
        #endregion

        #region Core
        protected override void SetSubscriptions(bool isSubscribed)
        {
            if (isSubscribed)
            {
                SignalBus.Subscribe<InitializeApplicationSignal>(OnInitializeApplicationSignal);
                SignalBus.Subscribe<QuitApplicationSignal>(OnQuitApplicationSignal);
            }
            else
            {
                SignalBus.Unsubscribe<InitializeApplicationSignal>(OnInitializeApplicationSignal);
                SignalBus.Unsubscribe<QuitApplicationSignal>(OnQuitApplicationSignal);
            }
        }
        #endregion

        #region SignalReceivers
        private void OnInitializeApplicationSignal(InitializeApplicationSignal signal) => InitializeApplication();
        private void OnQuitApplicationSignal(QuitApplicationSignal signal) => QuitApplication();
        #endregion
        
        #region Executes
        private void InitializeApplication()
        {
            UnityEngine.Application.targetFrameRate = _applicationModel.Settings.MaxFrameRate;
            UnityEngine.Application.runInBackground = _applicationModel.Settings.RunInBackground;

            Screen.sleepTimeout = SleepTimeout.NeverSleep;
        }
        private void QuitApplication()
        {
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#else
            UnityEngine.Application.Quit();
#endif
        }
        #endregion
    }
}