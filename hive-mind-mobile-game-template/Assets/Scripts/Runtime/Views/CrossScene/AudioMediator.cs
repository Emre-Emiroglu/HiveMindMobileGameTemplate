using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Controllers.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.CrossScene;
using CodeCatGames.HMModelViewController.Runtime;
using CodeCatGames.HMSignalBus.Runtime;
using VContainer.Unity;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Views.CrossScene
{
    public sealed class AudioMediator : Mediator<SettingsModel, Settings, AudioView>, IInitializable
    {
        #region ReadonlyFields
        private readonly SignalBus _signalBus;
        private readonly AudioController _controller;
        #endregion
        
        #region Constructor
        public AudioMediator(SettingsModel model, AudioView view, SignalBus signalBus,
            AudioController controller) : base(model, view)
        {
            _signalBus = signalBus;
            _controller = controller;
        }
        #endregion

        #region Core
        public override void SetSubscriptions(bool isSubscribed)
        {
            if (isSubscribed)
                _signalBus.Subscribe<PlayAudioSignal>(OnPlayAudioSignal);
            else
                _signalBus.Unsubscribe<PlayAudioSignal>(OnPlayAudioSignal);
        }
        #endregion

        #region SignalReceivers
        private void OnPlayAudioSignal(PlayAudioSignal signal) =>
            _controller.Execute(signal.AudioType, signal.MusicType, signal.SoundType);
        #endregion
    }
}