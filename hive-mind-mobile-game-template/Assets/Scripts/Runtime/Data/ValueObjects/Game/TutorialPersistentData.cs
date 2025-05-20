namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ValueObjects.Game
{
    public struct TutorialPersistentData
    {
        #region Fields
        public bool IsTutorialShowed;
        #endregion

        #region Constructor
        public TutorialPersistentData(bool isTutorialShowed) => IsTutorialShowed = isTutorialShowed;
        #endregion
    }
}