using System;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Enums.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Views.CrossScene;
using CodeCatGames.HMModelViewController.Runtime;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Controllers.CrossScene
{
    public sealed class AudioController : Controller<SettingsModel, Settings, AudioView>
    {
        #region Constructor
        public AudioController(SettingsModel model, AudioView view) : base(model, view) { }
        #endregion

        #region Executes
        public override void Execute(params object[] parameters)
        {
            AudioTypes audioType = (AudioTypes)parameters[0];
            MusicTypes musicType = (MusicTypes)parameters[1];
            SoundTypes soundType = (SoundTypes)parameters[2];
            
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
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        #endregion
    }
}