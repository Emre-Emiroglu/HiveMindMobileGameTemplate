using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.CrossScene;
using CodeCatGames.HMModelViewController.Runtime;
using UnityEngine.Audio;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.CrossScene
{
    public sealed class AudioModel : Model<AudioSettings>
    {
        #region Constants
        private const string AudioPath = "AUDIO_PATH";
        private const string MusicParam = "MUSIC_PARAM";
        private const string SoundParam = "SOUND_PARAM";
        #endregion

        #region ReadonlyFields
        private readonly AudioMixer _audioMixer;
        #endregion

        #region Fields
        private bool _isSoundMuted;
        private bool _isMusicMuted;
        #endregion

        #region Getters
        
        public bool IsSoundMuted => _isSoundMuted;
        public bool IsMusicMuted => _isMusicMuted;
        #endregion

        #region Constructor
        public AudioModel(AudioSettings settings) : base(settings)
        {
            _audioMixer = Settings.AudioMixer;
            
            LoadData();
            SetMusic(_isMusicMuted);
            SetSound(_isSoundMuted);
        }

        {

            _isMusicMuted = ES3.Load(nameof(_isMusicMuted), AudioPath, false);
            _isSoundMuted = ES3.Load(nameof(_isSoundMuted), AudioPath, false);
        }
        #endregion

        #region Executes
        public void SetMusic(bool isActive)
        {
            _isMusicMuted = isActive;
            _audioMixer.SetFloat(MusicParam, _isMusicMuted ? -80 : -20);

            Save();
        }
        public void SetSound(bool isActive)
        {
            _isSoundMuted = isActive;
            _audioMixer.SetFloat(SoundParam, _isSoundMuted ? -80 : -10);

            Save();
        }
        public void Save()
        {
            ES3.Save(nameof(_isMusicMuted), _isMusicMuted, AudioPath);
            ES3.Save(nameof(_isSoundMuted), _isSoundMuted, AudioPath);
        }
        #endregion

        public override void LoadData()
        {
            
        }
        public override void SaveData()
        {
        }
    }
}
