using System;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Controllers.Game;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.Game;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.Game;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.CrossScene;
using CodeCatGames.HMModelViewController.Runtime;
using CodeCatGames.HMSignalBus.Runtime;
using VContainer.Unity;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Views.Game
{
    public sealed class TutorialPanelMediator : Mediator<TutorialModel, TutorialSettings, TutorialPanelView>,
        IInitializable, IDisposable
    {
        #region ReadonlyFields
        private readonly SignalBus _signalBus;
        private readonly TutorialPanelActivationController _tutorialPanelActivationController;
        private readonly TutorialCloseButtonController _tutorialCloseButtonController;
        #endregion
        
        #region Constructor
        public TutorialPanelMediator(TutorialModel model, TutorialPanelView view, SignalBus signalBus,
            TutorialPanelActivationController tutorialPanelActivationController,
            TutorialCloseButtonController tutorialCloseButtonController) : base(model, view)
        {
            _signalBus = signalBus;
            _tutorialPanelActivationController = tutorialPanelActivationController;
            _tutorialCloseButtonController = tutorialCloseButtonController;
        }
        #endregion

        #region Core
        public override void SetSubscriptions(bool isSubscribed)
        {
            if (isSubscribed)
            {
                _signalBus.Subscribe<ChangeUIPanelSignal>(OnChangeUIPanelSignal);

                View.CloseButton.onClick.AddListener(OnCloseButtonClicked);
            }
            else
            {
                _signalBus.Unsubscribe<ChangeUIPanelSignal>(OnChangeUIPanelSignal);

                View.CloseButton.onClick.RemoveListener(OnCloseButtonClicked);
            }
        }
        #endregion

        #region SignalReceivers
        private void OnChangeUIPanelSignal(ChangeUIPanelSignal signal) =>
            _tutorialPanelActivationController.Execute(signal.UIPanelType);
        #endregion

        #region ButtonReceivers
        private void OnCloseButtonClicked() => _tutorialCloseButtonController.Execute();
        #endregion
    }
}