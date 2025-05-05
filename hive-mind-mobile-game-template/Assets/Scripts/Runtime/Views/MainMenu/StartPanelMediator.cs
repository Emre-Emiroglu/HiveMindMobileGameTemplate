using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Controllers.MainMenu;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.MainMenu;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.MainMenu;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.CrossScene;
using CodeCatGames.HMModelViewController.Runtime;
using CodeCatGames.HMSignalBus.Runtime;
using VContainer.Unity;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Views.MainMenu
{
    public sealed class StartPanelMediator : Mediator<MainMenuModel, MainMenuSettings, StartPanelView>, IInitializable
    {
        #region ReadonlyFields
        private readonly SignalBus _signalBus;
        private readonly StartPanelChangeUIPanelController _changeUIPanelController;
        private readonly StartPanelPlayButtonClickedController _playButtonClickedController;
        #endregion

        #region Constructor
        public StartPanelMediator(MainMenuModel model, StartPanelView view, SignalBus signalBus,
            StartPanelChangeUIPanelController changeUIPanelController,
            StartPanelPlayButtonClickedController playButtonClickedController) : base(model, view)
        {
            _signalBus = signalBus;
            _changeUIPanelController = changeUIPanelController;
            _playButtonClickedController = playButtonClickedController;
        }
        #endregion

        #region Core
        void IInitializable.Initialize() => base.Initialize();
        public override void SetSubscriptions(bool isSubscribed)
        {
            if (isSubscribed)
            {
                _signalBus.Subscribe<ChangeUIPanelSignal>(OnChangeUIPanelSignal);

                View.PlayButton.onClick.AddListener(OnPlayButtonClicked);
            }
            else
            {
                _signalBus.Unsubscribe<ChangeUIPanelSignal>(OnChangeUIPanelSignal);

                View.PlayButton.onClick.RemoveListener(OnPlayButtonClicked);
            }
        }
        #endregion

        #region SignalReceivers
        private void OnChangeUIPanelSignal(ChangeUIPanelSignal signal) =>
            _changeUIPanelController.Execute(signal.UIPanelType);
        #endregion
        
        #region ButtonReceivers
        private void OnPlayButtonClicked() => _playButtonClickedController.Execute();
        #endregion
    }
}