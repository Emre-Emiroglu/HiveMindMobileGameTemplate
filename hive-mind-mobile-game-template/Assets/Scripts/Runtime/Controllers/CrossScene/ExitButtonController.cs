using HMModelViewController.Runtime;
using HMSignalBus.Runtime;
using HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.CrossScene;
using HiveMindMobileGameTemplate.Runtime.Enums.CrossScene;
using HiveMindMobileGameTemplate.Runtime.Models.CrossScene;
using HiveMindMobileGameTemplate.Runtime.Signals.Application;
using HiveMindMobileGameTemplate.Runtime.Signals.CrossScene;
using HiveMindMobileGameTemplate.Runtime.Signals.Game;
using HiveMindMobileGameTemplate.Runtime.Views.CrossScene;
using UnityEngine.SceneManagement;

namespace HiveMindMobileGameTemplate.Runtime.Controllers.CrossScene
{
    public sealed class ExitButtonController : Controller<SettingsModel, Settings, SettingsView>
    {
        #region ReadonylFields
        private readonly SignalBus _signalBus;
        #endregion
        
        #region Constructor
        public ExitButtonController(SettingsModel model, SettingsView view, SignalBus signalBus) : base(model,
            view) => _signalBus = signalBus;
        #endregion

        #region Executes
        public override void Execute(params object[] parameters)
        {
            SceneID currentSceneID = (SceneID)SceneManager.GetActiveScene().buildIndex;

            switch (currentSceneID)
            {
                case SceneID.Bootstrap:
                    break;
                case SceneID.MainMenu:
                    _signalBus.Fire(new QuitApplicationSignal());
                    break;
                case SceneID.Game:
                    _signalBus.Fire(new GameExitSignal());
                    _signalBus.Fire(new PlayAudioSignal(AudioTypes.Sound, MusicTypes.BackgroundMusic,
                        SoundTypes.UIClick));
                    break;
            }
        }
        #endregion
    }
}