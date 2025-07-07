using HMModelViewController.Runtime;
using HMSignalBus.Runtime;
using HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.MainMenu;
using HiveMindMobileGameTemplate.Runtime.Enums.CrossScene;
using HiveMindMobileGameTemplate.Runtime.Models.MainMenu;
using HiveMindMobileGameTemplate.Runtime.Signals.CrossScene;
using HiveMindMobileGameTemplate.Runtime.Views.MainMenu;

namespace HiveMindMobileGameTemplate.Runtime.Controllers.MainMenu
{
    public sealed class PlayButtonController : Controller<MainMenuModel, MainMenuSettings, StartPanelView>
    {
        #region ReadonlyFields
        private readonly SignalBus _signalBus;
        #endregion
        
        #region Constructor
        public PlayButtonController(MainMenuModel model, StartPanelView view, SignalBus signalBus) :
            base(model, view) => _signalBus = signalBus;
        #endregion
        
        #region Executes
        public override void Execute(params object[] parameters)
        {
            _signalBus.Fire(new PlayAudioSignal(AudioTypes.Sound, MusicTypes.BackgroundMusic, SoundTypes.UIClick));
            
            _signalBus.Fire(new LoadSceneSignal(SceneID.Game));
        }
        #endregion
    }
}