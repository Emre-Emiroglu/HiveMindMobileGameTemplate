using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Enums.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.Game;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.Game;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Controllers.Game
{
    public sealed class InitializeGameCommand : Command<InitializeGameSignal>
    {
        #region ReadonlyFields
        private readonly SignalBus _signalBus;
        private readonly TutorialModel _tutorialModel;
        #endregion

        #region Constructor
        public InitializeGameCommand(SignalBus signalBus, TutorialModel tutorialModel)
        {
            _signalBus = signalBus;
            _tutorialModel = tutorialModel;
        }
        #endregion

        #region Executes
        public override void Execute(InitializeGameSignal signal)
        {
            _signalBus.Fire(new ChangeLoadingScreenActivationSignal(false, null));

            if (_tutorialModel.IsTutorialShowed)
                _signalBus.Fire(new PlayGameSignal());
            else
                _signalBus.Fire(new ChangeUIPanelSignal(UIPanelTypes.TutorialPanel));
        }
        #endregion
    }
}
