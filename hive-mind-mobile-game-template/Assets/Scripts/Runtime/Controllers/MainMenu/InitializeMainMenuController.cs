using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Enums.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.MainMenu;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Temp;
using CodeCatGames.HMSignalBus.Runtime;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Controllers.MainMenu
{
    public sealed class InitializeMainMenuController : SignalListener
    {
        #region Constructor
        public InitializeMainMenuController(SignalBus signalBus) : base(signalBus) { }
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
        private void OnInitializeMainMenuSignal(InitializeMainMenuSignal signal)
        {
            SignalBus.Fire(new ChangeLoadingScreenActivationSignal(null, false));
            SignalBus.Fire(new ChangeUIPanelSignal(UIPanelTypes.StartPanel));
            SignalBus.Fire(new PlayAudioSignal(AudioTypes.Music, MusicTypes.BackgroundMusic, SoundTypes.UIClick));
        }
        #endregion
    }
}