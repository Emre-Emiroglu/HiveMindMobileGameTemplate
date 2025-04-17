using System;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.Application;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.Application;
using CodeCatGames.HMSignalBus.Runtime;
using UnityEngine;
using VContainer.Unity;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Controllers.Application
{
    public sealed class AppInitController : IInitializable, IDisposable
    {
        #region ReadonlyFields
        private readonly SignalBus _signalBus;
        private readonly ApplicationModel _applicationModel;
        #endregion

        #region Constructor
        public AppInitController(SignalBus signalBus, ApplicationModel applicationModel)
        {
            _signalBus = signalBus;
            _applicationModel = applicationModel;
        }
        #endregion

        #region Core
        public void Initialize() => _signalBus.Subscribe<InitAppSignal>(OnInitAppSignal);
        public void Dispose() => _signalBus.Unsubscribe<InitAppSignal>(OnInitAppSignal);
        #endregion

        #region SignalReceivers
        private void OnInitAppSignal(InitAppSignal signal) => Execute();
        #endregion

        #region Executes
        private void Execute()
        {
            UnityEngine.Application.targetFrameRate = _applicationModel.Settings.TargetFrameRate;
            UnityEngine.Application.runInBackground = _applicationModel.Settings.RunInBackground;

            Screen.sleepTimeout = SleepTimeout.NeverSleep;
        }
        #endregion
    }
}