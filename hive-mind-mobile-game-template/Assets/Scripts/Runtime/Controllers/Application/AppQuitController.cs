using System;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.Application;
using CodeCatGames.HMSignalBus.Runtime;
using UnityEditor;
using VContainer.Unity;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Controllers.Application
{
    public sealed class AppQuitController : IInitializable, IDisposable
    {
        #region ReadonlyFields
        private readonly SignalBus _signalBus;
        #endregion

        #region Constructor
        public AppQuitController(SignalBus signalBus) => _signalBus = signalBus;
        #endregion
        
        #region Core
        public void Initialize() => _signalBus.Subscribe<QuitAppSignal>(OnQuitAppSignal);
        public void Dispose() => _signalBus.Unsubscribe<QuitAppSignal>(OnQuitAppSignal);
        #endregion

        #region SignalReceivers
        private void OnQuitAppSignal(QuitAppSignal signal) => Execute();
        #endregion
        
        #region Executes
        private void Execute()
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
