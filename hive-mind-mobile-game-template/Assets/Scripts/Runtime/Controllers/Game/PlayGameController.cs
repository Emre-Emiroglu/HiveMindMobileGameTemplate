using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Enums.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.Game;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.Game;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Temp;
using CodeCatGames.HMSignalBus.Runtime;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Controllers.Game
{
    public sealed class PlayGameController : SignalListener
    {

        public PlayGameController(SignalBus signalBus, TutorialModel tutorialModel) : base(signalBus)
        {
        }
        protected override void SetSubscriptions(bool isSubscribed)
        {
            if (isSubscribed)
            {
                SignalBus.Subscribe<PlayGameSignal>(OnPlayGameSignal);
            }
            else
            {
                SignalBus.Unsubscribe<PlayGameSignal>(OnPlayGameSignal);
                
            }
        }

        private void OnPlayGameSignal(PlayGameSignal signal) => SignalBus.Fire(new ChangeUIPanelSignal(UIPanelTypes.InGamePanel));
    }
}