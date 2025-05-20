using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Enums.CrossScene;
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
        #endregion
        
        #region Constructor
        public AudioMediator(SettingsModel model, AudioView view, SignalBus signalBus) : base(model, view) =>
            _signalBus = signalBus;
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
            PlayAudio(signal.AudioType, signal.MusicType, signal.SoundType);
        #endregion

        #region Executes
        private void PlayAudio(AudioTypes audioType, MusicTypes musicType, SoundTypes soundType)
        {
            switch (audioType)
            {
                case AudioTypes.Music:
                    View.AudioSources[audioType].clip = Model.Settings.Musics[musicType];
                    View.AudioSources[audioType].loop = true;
                    View.AudioSources[audioType].Play();
                    break;
                case AudioTypes.Sound:
                    View.AudioSources[audioType].PlayOneShot(Model.Settings.Sounds[soundType]);
                    break;
            }
        }
        #endregion
    }
}