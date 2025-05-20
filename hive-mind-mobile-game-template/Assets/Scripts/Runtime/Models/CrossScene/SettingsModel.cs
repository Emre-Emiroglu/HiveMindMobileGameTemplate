using System;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ValueObjects.CrossScene;
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
                SetMusic(_settingsPersistentData.IsMusicMuted);
                SetSound(_settingsPersistentData.IsSoundMuted);
                SetHaptic(_settingsPersistentData.IsHapticMuted);
            }
        }
        #endregion

        #region Executes
        public void SetMusic(bool isActive)
        {
            _settingsPersistentData.IsMusicMuted = isActive;
            
            _audioMixer.SetFloat(MusicParam, _settingsPersistentData.IsMusicMuted ? -80 : -20);

            SaveData();
        }
        public void SetSound(bool isActive)
        {
            _settingsPersistentData.IsSoundMuted = isActive;
            
            _audioMixer.SetFloat(SoundParam, _settingsPersistentData.IsSoundMuted ? -80 : -10);

            SaveData();
        }
        public void SetHaptic(bool isActive)
        {
            _settingsPersistentData.IsHapticMuted = isActive;

            SaveData();
        }
        public override void LoadData() => _settingsPersistentData =
            PersistentDataServiceUtilities.Load<SettingsPersistentData>(nameof(_settingsPersistentData));
        public override void SaveData() =>
            PersistentDataServiceUtilities.Save(nameof(_settingsPersistentData), _settingsPersistentData);
        #endregion
    }
}