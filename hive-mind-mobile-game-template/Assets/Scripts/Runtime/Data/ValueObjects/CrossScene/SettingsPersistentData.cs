namespace HiveMindMobileGameTemplate.Runtime.Data.ValueObjects.CrossScene
{
    public struct SettingsPersistentData
    {
        #region Fields
        public bool IsSoundMuted;
        public bool IsMusicMuted;
        public bool IsHapticMuted;
        #endregion
        
        #region Constructor
        public SettingsPersistentData(bool isSoundMuted, bool isMusicMuted, bool isHapticMuted)
        {
            IsSoundMuted = isSoundMuted;
            IsMusicMuted = isMusicMuted;
            IsHapticMuted = isHapticMuted;
        }
        #endregion
    }
}