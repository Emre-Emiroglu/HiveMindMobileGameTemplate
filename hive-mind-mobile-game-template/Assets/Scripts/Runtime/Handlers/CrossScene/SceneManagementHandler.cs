using HMSignalBus.Runtime;
using HiveMindMobileGameTemplate.Runtime.Enums.CrossScene;
using HiveMindMobileGameTemplate.Runtime.Signals.CrossScene;
using HiveMindMobileGameTemplate.Runtime.Temp;
using UnityEngine.SceneManagement;

namespace HiveMindMobileGameTemplate.Runtime.Handlers.CrossScene
{
    public sealed class SceneManagementHandler : SignalListener
    {
        #region Constructor
        public SceneManagementHandler(SignalBus signalBus) : base(signalBus) { }
        #endregion

        #region Core
        protected override void SetSubscriptions(bool isSubscribed)
        {
            if (isSubscribed)
                SignalBus.Subscribe<LoadSceneSignal>(OnLoadSceneSignal);
            else
                SignalBus.Unsubscribe<LoadSceneSignal>(OnLoadSceneSignal);
        }
        #endregion

        #region SignalReceivers
        private void OnLoadSceneSignal(LoadSceneSignal signal) => LoadScene(signal.SceneID);
        #endregion

        #region Executes
        private void LoadScene(SceneID sceneID) => SceneManager.LoadScene((int)sceneID);
        #endregion
    }
}