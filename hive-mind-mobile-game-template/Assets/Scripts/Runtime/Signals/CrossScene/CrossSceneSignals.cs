using HiveMindMobileGameTemplate.Runtime.Enums.CrossScene;

namespace HiveMindMobileGameTemplate.Runtime.Signals.CrossScene
{
    public readonly struct LoadSceneSignal
    {
        #region Properities
        public SceneID SceneID { get; }
        #endregion

        #region Constructor
        public LoadSceneSignal(SceneID sceneID) => SceneID = sceneID;
        #endregion
    }
    public readonly struct PlayAudioSignal
    {
        #region Properities
        public AudioTypes AudioType { get; }
        public MusicTypes MusicType { get; }
        public SoundTypes SoundType { get; }
        #endregion

        #region Constructor
        public PlayAudioSignal(AudioTypes audioType, MusicTypes musicType, SoundTypes soundType)
        {
            AudioType = audioType;
            MusicType = musicType;
            SoundType = soundType;
        }
        #endregion
    }
    public readonly struct ChangeCurrencySignal
    {
        #region Properities
        public CurrencyTypes CurrencyType { get; }
        public int Amount { get; }
        public bool IsSet { get; }
        #endregion

        #region Constructor
        public ChangeCurrencySignal(CurrencyTypes currencyType, int amount, bool isSet)
        {
            CurrencyType = currencyType;
            Amount = amount;
            IsSet = isSet;
        }
        #endregion
    }
    public readonly struct RefreshCurrencyVisualSignal
    {
        #region Properities
        public CurrencyTypes CurrencyType { get; }
        #endregion

        #region Constructor
        public RefreshCurrencyVisualSignal(CurrencyTypes currencyType) => CurrencyType = currencyType;
        #endregion
    }
    public readonly struct ChangeUIPanelSignal
    {
        #region Properities
        public UIPanelTypes UIPanelType { get; }
        #endregion

        #region Constructor
        public ChangeUIPanelSignal(UIPanelTypes uiPanelType) => UIPanelType = uiPanelType;
        #endregion
    }
}
