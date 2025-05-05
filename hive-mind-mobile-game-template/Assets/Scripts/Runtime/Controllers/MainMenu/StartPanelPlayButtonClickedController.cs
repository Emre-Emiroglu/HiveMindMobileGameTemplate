using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.MainMenu;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Enums.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.MainMenu;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Views.MainMenu;
using CodeCatGames.HMModelViewController.Runtime;
using CodeCatGames.HMSignalBus.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Controllers.MainMenu
{
    public sealed class StartPanelPlayButtonClickedController : Controller<MainMenuModel, MainMenuSettings, StartPanelView>
    {
        #region ReadonlyFields
        private readonly SignalBus _signalBus;
        #endregion
        
        #region Constructor
        public StartPanelPlayButtonClickedController(MainMenuModel model, StartPanelView view, SignalBus signalBus) :
            base(model, view) => _signalBus = signalBus;
        #endregion

        #region Executes
        public override void Execute(params object[] parameters)
        {
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync((int)SceneID.Game);
            
            _signalBus.Fire(new ChangeLoadingScreenActivationSignal(asyncOperation, true));
            _signalBus.Fire(new PlayAudioSignal(AudioTypes.Sound, MusicTypes.BackgroundMusic, SoundTypes.UIClick));
        }
        #endregion
    }
}