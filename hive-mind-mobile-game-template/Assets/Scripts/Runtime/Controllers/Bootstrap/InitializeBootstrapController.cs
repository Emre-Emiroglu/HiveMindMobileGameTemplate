using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Enums.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.Bootstrap;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.Bootstrap;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Temp;
using CodeCatGames.HMSignalBus.Runtime;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Controllers.Bootstrap
{
    public sealed class InitializeBootstrapController : SignalListener
    {
        #region ReadonlyFields
        private readonly BootstrapModel _bootstrapModel;
        #endregion

        #region Contructor
        public InitializeBootstrapController(SignalBus signalBus, BootstrapModel bootstrapModel) : base(signalBus) =>
            _bootstrapModel = bootstrapModel;
        #endregion

        #region Core
        protected override void SetSubscriptions(bool isSubscribed)
        {
            if (isSubscribed)
                SignalBus.Subscribe<InitializeBootstrapSignal>(OnInitializeBootstrapSignal);
            else
                SignalBus.Unsubscribe<InitializeBootstrapSignal>(OnInitializeBootstrapSignal);
        }
        #endregion

        #region SignalReceivers
        private void OnInitializeBootstrapSignal(InitializeBootstrapSignal signal) => InitializeBootstrap().Forget();
        #endregion
        
        #region Executes
        private async UniTaskVoid InitializeBootstrap()
        {
            int millisecondsDelay = (int)(_bootstrapModel.Settings.SceneActivationDuration * 1000f);
            
            await UniTask.Delay(millisecondsDelay);
            
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync((int)SceneID.MainMenu);

            SignalBus.Fire(new ChangeLoadingScreenActivationSignal(asyncOperation, true));
        }
        #endregion
    }
}
