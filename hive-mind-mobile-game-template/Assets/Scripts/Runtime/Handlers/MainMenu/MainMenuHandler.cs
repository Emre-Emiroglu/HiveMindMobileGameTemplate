using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Enums.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.MainMenu;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Temp;
using CodeCatGames.HMSignalBus.Runtime;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Handlers.MainMenu
{
    public sealed class MainMenuHandler : SignalListener
    {
        #region Constructor
        public MainMenuHandler(SignalBus signalBus) : base(signalBus) { }
        #endregion

        #region Core
        protected override void SetSubscriptions(bool isSubscribed)
        {
            if (isSubscribed)
                SignalBus.Subscribe<InitializeMainMenuSignal>(OnInitializeMainMenuSignal);
            else
                SignalBus.Unsubscribe<InitializeMainMenuSignal>(OnInitializeMainMenuSignal);
        }
        #endregion

        #region SignalReceivers
        private void OnInitializeMainMenuSignal(InitializeMainMenuSignal signal) => InitializeMainMenu();
        #endregion

        #region Executes
        private void InitializeMainMenu()
        {
            SignalBus.Fire(new ChangeUIPanelSignal(UIPanelTypes.StartPanel));
            SignalBus.Fire(new PlayAudioSignal(AudioTypes.Music, MusicTypes.BackgroundMusic, SoundTypes.UIClick));
        }
        #endregion
    }
}