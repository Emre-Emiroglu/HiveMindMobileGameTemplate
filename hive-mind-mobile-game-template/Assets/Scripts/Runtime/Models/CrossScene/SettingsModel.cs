using System;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.CrossScene;
using CodeCatGames.HMModelViewController.Runtime;
using CodeCatGames.HMPersistentData.Runtime;
using UnityEngine.Audio;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.CrossScene
{
    public sealed class SettingsModel : Model<Settings>
    {
        #region Constants
        private const string MusicParam = "MUSIC_PARAM";
        private const string SoundParam = "SOUND_PARAM";
        #endregion
        
        #region ReadonlyFields
        private readonly AudioMixer _audioMixer;
        #endregion

        #region Fields
        private bool _isSoundMuted;
        private bool _isMusicMuted;
        private bool _isHapticMuted;
        #endregion
        
        #region Getters
        public bool IsSoundMuted => _isSoundMuted;
        public bool IsMusicMuted => _isMusicMuted;
        public bool IsHapticMuted => _isHapticMuted;
        #endregion

        #region Constructor
        public SettingsModel(Settings settings) : base(settings)
        {
            _audioMixer = Settings.AudioMixer;
            
            try
            {
                LoadData();
            }
            catch (Exception)
            {
                SetMusic(_isMusicMuted);
                SetSound(_isSoundMuted);
                SetHaptic(_isHapticMuted);
            }
        }
        #endregion

        #region Executes
        public void SetMusic(bool isActive)
        {
            _isMusicMuted = isActive;
            _audioMixer.SetFloat(MusicParam, _isMusicMuted ? -80 : -20);

            SaveData();
        }
        public void SetSound(bool isActive)
        {
            _isSoundMuted = isActive;
            _audioMixer.SetFloat(SoundParam, _isSoundMuted ? -80 : -10);

            SaveData();
        }
        public void SetHaptic(bool isActive)
        {
            _isHapticMuted = isActive;

            SaveData();
        }
        public override void LoadData()
        {
            _isSoundMuted = PersistentDataServiceUtilities.Load<bool>(nameof(_isSoundMuted));
            _isMusicMuted = PersistentDataServiceUtilities.Load<bool>(nameof(_isMusicMuted));
            _isHapticMuted = PersistentDataServiceUtilities.Load<bool>(nameof(_isHapticMuted));
        }
        public override void SaveData()
        {
            PersistentDataServiceUtilities.Save(nameof(_isSoundMuted), _isSoundMuted);
            PersistentDataServiceUtilities.Save(nameof(_isMusicMuted), _isSoundMuted);
            PersistentDataServiceUtilities.Save(nameof(_isHapticMuted), _isHapticMuted);
        }
        #endregion
    }
}