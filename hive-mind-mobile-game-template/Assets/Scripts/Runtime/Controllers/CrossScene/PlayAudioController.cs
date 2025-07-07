using HMModelViewController.Runtime;
using HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.CrossScene;
using HiveMindMobileGameTemplate.Runtime.Enums.CrossScene;
using HiveMindMobileGameTemplate.Runtime.Models.CrossScene;
using HiveMindMobileGameTemplate.Runtime.Views.CrossScene;

namespace HiveMindMobileGameTemplate.Runtime.Controllers.CrossScene
{
    public sealed class PlayAudioController : Controller<SettingsModel, Settings, AudioView>
    {
        #region Constructor
        public PlayAudioController(SettingsModel model, AudioView view) : base(model, view) { }
        #endregion

        #region Executes
        public override void Execute(params object[] parameters)
        {
            AudioTypes audioType = (AudioTypes) parameters[0];
            MusicTypes musicType = (MusicTypes) parameters[1];
            SoundTypes soundType = (SoundTypes) parameters[2];
            
            switch (audioType)
            {
                case AudioTypes.Music:
                    View.AudioSources[audioType].clip = Model.Settings.Musics[musicType];
                    View.AudioSources[audioType].loop = true;
                    View.AudioSources[audioType].Play();
                    break;
                case AudioTypes.Sound:
                    View.AudioSources[audioType].PlayOneShot(Model.Settings.Sounds[soundType]);
                    break;
            }
        }
        #endregion
    }
}