using HMModelViewController.Runtime;
using HMSignalBus.Runtime;
using HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.CrossScene;
using HiveMindMobileGameTemplate.Runtime.Enums.CrossScene;
using HiveMindMobileGameTemplate.Runtime.Models.CrossScene;
using HiveMindMobileGameTemplate.Runtime.Signals.CrossScene;
using HiveMindMobileGameTemplate.Runtime.Views.CrossScene;

namespace HiveMindMobileGameTemplate.Runtime.Controllers.CrossScene
{
    public sealed class CurrencyButtonController : Controller<CurrencyModel, CurrencySettings, CurrencyView>
    {
        #region ReadonlyFields
        private readonly SignalBus _signalBus;
        #endregion
        
        #region Constructor
        public CurrencyButtonController(CurrencyModel model, CurrencyView view, SignalBus signalBus) :
            base(model, view) => _signalBus = signalBus;
        #endregion

        #region Executes
        public override void Execute(params object[] parameters)
        {
            _signalBus.Fire(new ChangeUIPanelSignal(UIPanelTypes.ShopPanel));
            _signalBus.Fire(new PlayAudioSignal(AudioTypes.Sound, MusicTypes.BackgroundMusic, SoundTypes.UIClick));
        }
        #endregion
    }
}