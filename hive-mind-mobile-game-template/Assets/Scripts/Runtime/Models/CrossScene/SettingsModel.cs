using System;
using HMModelViewController.Runtime;
using HMPersistentData.Runtime;
using HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.CrossScene;
using HiveMindMobileGameTemplate.Runtime.Data.ValueObjects.CrossScene;
using UnityEngine.Audio;

namespace HiveMindMobileGameTemplate.Runtime.Models.CrossScene
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
        private SettingsPersistentData _settingsPersistentData;
        #endregion
        
        #region Getters
        public SettingsPersistentData SettingsPersistentData => _settingsPersistentData;
        #endregion

        #region Constructor
        public SettingsModel(Settings settings) : base(settings)
        {
            _audioMixer = Settings.AudioMixer;

            _settingsPersistentData = new SettingsPersistentData(false, false, false);
            
            try
            {
                LoadData();
            }
            catch (Exception)
            {
                SaveData();
            }
        }
        #endregion

        #region Executes
        public void SetMusic(bool isMuted)
        {
            _settingsPersistentData.IsMusicMuted = isMuted;
            
            _audioMixer.SetFloat(MusicParam, _settingsPersistentData.IsMusicMuted ? -80 : -20);

            SaveData();
        }
        public void SetSound(bool isMuted)
        {
            _settingsPersistentData.IsSoundMuted = isMuted;
            
            _audioMixer.SetFloat(SoundParam, _settingsPersistentData.IsSoundMuted ? -80 : -10);

            SaveData();
        }
        public void SetHaptic(bool isMuted)
        {
            _settingsPersistentData.IsHapticMuted = isMuted;

            SaveData();
        }
        public override void LoadData() => _settingsPersistentData =
            PersistentDataServiceUtilities.Load<SettingsPersistentData>(nameof(_settingsPersistentData));
        public override void SaveData() =>
            PersistentDataServiceUtilities.Save(nameof(_settingsPersistentData), _settingsPersistentData);
        #endregion
    }
}