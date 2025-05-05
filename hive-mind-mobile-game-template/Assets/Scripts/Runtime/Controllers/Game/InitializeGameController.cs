using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Enums.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.Game;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.Game;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Temp;
using CodeCatGames.HMSignalBus.Runtime;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Controllers.Game
{
    public sealed class InitializeGameController : SignalListener
    {
        private readonly TutorialModel _tutorialModel;

        public InitializeGameController(SignalBus signalBus, TutorialModel tutorialModel) : base(signalBus)
        {
            _tutorialModel = tutorialModel;
        }
        protected override void SetSubscriptions(bool isSubscribed)
        {
            if (isSubscribed)
            {
                SignalBus.Subscribe<InitializeGameSignal>(OnInitializeGameSignal);
            }
            else
            {
                SignalBus.Unsubscribe<InitializeGameSignal>(OnInitializeGameSignal);
                
            }
        }

        private void OnInitializeGameSignal(InitializeGameSignal signal)
        {
            SignalBus.Fire(new ChangeLoadingScreenActivationSignal(null, false));

            if (_tutorialModel.IsTutorialShowed)
                SignalBus.Fire(new PlayGameSignal());
            else
                SignalBus.Fire(new ChangeUIPanelSignal(UIPanelTypes.TutorialPanel));
        }
    }
}