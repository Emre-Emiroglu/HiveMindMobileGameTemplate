using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.Application;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Temp;
using CodeCatGames.HMSignalBus.Runtime;
using UnityEditor;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Controllers.Application
{
    public sealed class QuitApplicationController : SignalListener
    {
        #region Constructor
        public QuitApplicationController(SignalBus signalBus) : base(signalBus) { }
        #endregion

        #region Core
        protected override void SetSubscriptions(bool isSubscribed)
        {
            if (isSubscribed)
                SignalBus.Subscribe<QuitApplicationSignal>(OnQuitApplicationSignal);
            else
                SignalBus.Unsubscribe<QuitApplicationSignal>(OnQuitApplicationSignal);
        }
        #endregion

        #region SignalReceivers
        private void OnQuitApplicationSignal(QuitApplicationSignal signal) => QuitApplication();
        #endregion

        #region Executes
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