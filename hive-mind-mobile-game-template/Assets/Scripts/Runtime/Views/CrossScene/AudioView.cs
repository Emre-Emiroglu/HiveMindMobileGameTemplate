using AYellowpaper.SerializedCollections;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Enums.CrossScene;
using CodeCatGames.HMModelViewController.Runtime;
using UnityEngine;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Views.CrossScene
{
    public sealed class AudioView : View
    {
        #region Fields
        [Header("Audio View Fields")]
        [SerializeField] private SerializedDictionary<AudioTypes, AudioSource> audioSources;
        #endregion

        #region Getters
        public SerializedDictionary<AudioTypes, AudioSource> AudioSources => audioSources;
        #endregion
    }
}