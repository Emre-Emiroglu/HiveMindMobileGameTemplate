using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Enums.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.Game;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Temp;
using CodeCatGames.HMSignalBus.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Controllers.Game
{
    public sealed class GameExitController : SignalListener
    {
        public GameExitController(SignalBus signalBus) : base(signalBus)
        {
        }

        protected override void SetSubscriptions(bool isSubscribed)
        {
            if (isSubscribed)
            {
                SignalBus.Subscribe<GameExitSignal>(OnGameExitSignal);
            }
            else
            {
                SignalBus.Unsubscribe<GameExitSignal>(OnGameExitSignal);
                
            }
        }

        private void OnGameExitSignal(GameExitSignal signal)
        {
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync((int)SceneID.MainMenu);

            SignalBus.Fire(new ChangeLoadingScreenActivationSignal(asyncOperation, true));
        }
    }
}