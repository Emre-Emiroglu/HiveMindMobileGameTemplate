using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Controllers.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.CrossScene;
using CodeCatGames.HMModelViewController.Runtime;
using CodeCatGames.HMSignalBus.Runtime;
using VContainer.Unity;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Views.CrossScene
{
    public sealed class LoadingScreenPanelMediator : Mediator<CrossSceneModel, CrossSceneSettings, LoadingScreenPanelView>, IInitializable
    {
        #region ReadonlyFields
        private readonly SignalBus _signalBus;
        private readonly LoadingScreenPanelController _loadingScreenPanelController;
        #endregion

        #region Constructor
        public LoadingScreenPanelMediator(CrossSceneModel model, LoadingScreenPanelView view, SignalBus signalBus,
            LoadingScreenPanelController loadingScreenPanelController) : base(model, view)
        {
            _signalBus = signalBus;
            _loadingScreenPanelController = loadingScreenPanelController;
        }
        #endregion

        #region Core
        void IInitializable.Initialize()
        {
            base.Initialize();

            _loadingScreenPanelController.Execute(null, false);
        }
        public override void SetSubscriptions(bool isSubscribed)
        {
            if (isSubscribed)
                _signalBus.Subscribe<ChangeLoadingScreenActivationSignal>(OnChangeLoadingScreenActivationSignal);
            else
                _signalBus.Unsubscribe<ChangeLoadingScreenActivationSignal>(OnChangeLoadingScreenActivationSignal);
        }
        #endregion

        #region SignalReceivers
        private void OnChangeLoadingScreenActivationSignal(ChangeLoadingScreenActivationSignal signal) =>
            _loadingScreenPanelController.Execute(signal.AsyncOperation, signal.IsActive);
        #endregion
    }
}