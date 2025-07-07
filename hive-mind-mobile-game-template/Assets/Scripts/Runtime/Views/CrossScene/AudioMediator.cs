using System;
using HMModelViewController.Runtime;
using HMSignalBus.Runtime;
using HiveMindMobileGameTemplate.Runtime.Controllers.CrossScene;
using HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.CrossScene;
using HiveMindMobileGameTemplate.Runtime.Models.CrossScene;
using HiveMindMobileGameTemplate.Runtime.Signals.CrossScene;
using VContainer.Unity;

namespace HiveMindMobileGameTemplate.Runtime.Views.CrossScene
{
    public sealed class AudioMediator : Mediator<SettingsModel, Settings, AudioView>, IInitializable, IDisposable
    {
        #region ReadonlyFields
        private readonly SignalBus _signalBus;
        private readonly PlayAudioController _playAudioController;
        private readonly AdjustSettingsController _adjustSettingsController;
        #endregion
        
        #region Constructor
        public AudioMediator(SettingsModel model, AudioView view, SignalBus signalBus,
            PlayAudioController playAudioController, AdjustSettingsController adjustSettingsController) : base(model,
            view)
        {
            _signalBus = signalBus;
            _playAudioController = playAudioController;
            _adjustSettingsController = adjustSettingsController;
        }
        #endregion

        #region Core
        public override void SetSubscriptions(bool isSubscribed)
        {
            if (isSubscribed)
            {
                _signalBus.Subscribe<PlayAudioSignal>(OnPlayAudioSignal);

                View.StartAction += OnStartAction;
            }
            else
            {
                _signalBus.Unsubscribe<PlayAudioSignal>(OnPlayAudioSignal);
                
                View.StartAction -= OnStartAction;
            }
        }
        #endregion

        #region SignalReceivers
        private void OnPlayAudioSignal(PlayAudioSignal signal) =>
            _playAudioController.Execute(signal.AudioType, signal.MusicType, signal.SoundType);
        #endregion

        #region ViewReceivers
        private void OnStartAction() => _adjustSettingsController.Execute();
        #endregion
    }
}