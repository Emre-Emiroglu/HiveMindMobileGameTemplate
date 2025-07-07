using HMModelViewController.Runtime;
using HMSignalBus.Runtime;
using HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.MainMenu;
using HiveMindMobileGameTemplate.Runtime.Enums.CrossScene;
using HiveMindMobileGameTemplate.Runtime.Models.MainMenu;
using HiveMindMobileGameTemplate.Runtime.Signals.CrossScene;
using HiveMindMobileGameTemplate.Runtime.Views.MainMenu;

namespace HiveMindMobileGameTemplate.Runtime.Controllers.MainMenu
{
    public sealed class HomeButtonController : Controller<MainMenuModel, MainMenuSettings, ShopPanelView>
    {
        #region ReadonlyFields
        private readonly SignalBus _signalBus;
        #endregion
        
        #region Constructor
        public HomeButtonController(MainMenuModel model, ShopPanelView view, SignalBus signalBus) : base(model, view) =>
            _signalBus = signalBus;
        #endregion
        
        #region Executes
        public override void Execute(params object[] parameters)
        {
            _signalBus.Fire(new ChangeUIPanelSignal(UIPanelTypes.StartPanel));
            _signalBus.Fire(new PlayAudioSignal(AudioTypes.Sound, MusicTypes.BackgroundMusic, SoundTypes.UIClick));
        }
        #endregion
    }
}