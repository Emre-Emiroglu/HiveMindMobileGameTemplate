using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.CrossScene;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Controllers.CrossScene
{
    public sealed class LoadSceneCommand : Command<LoadSceneSignal>
    {
        #region ReadonlyFields
        private readonly SignalBus _signalBus;
        #endregion

        #region Constructor
        public LoadSceneCommand(SignalBus signalBus) => _signalBus = signalBus;
        #endregion

        #region Executes
        public override void Execute(LoadSceneSignal signal)
        {
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync((int)signal.SceneId);

            _signalBus.Fire(new ChangeLoadingScreenActivationSignal(true, asyncOperation));
        }
        #endregion
    }
}
