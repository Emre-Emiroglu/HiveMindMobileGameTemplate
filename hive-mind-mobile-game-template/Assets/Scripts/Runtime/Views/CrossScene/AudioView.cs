using System;
using AYellowpaper.SerializedCollections;
using HMModelViewController.Runtime;
using HiveMindMobileGameTemplate.Runtime.Enums.CrossScene;
using UnityEngine;

namespace HiveMindMobileGameTemplate.Runtime.Views.CrossScene
{
    public sealed class AudioView : View
    {
        #region Actions
        public event Action StartAction;
        #endregion
        
        #region Fields
        [Header("Audio View Fields")]
        [SerializeField] private SerializedDictionary<AudioTypes, AudioSource> audioSources;
        #endregion

        #region Getters
        public SerializedDictionary<AudioTypes, AudioSource> AudioSources => audioSources;
        #endregion

        #region Core
        private void Start() => StartAction?.Invoke();
        #endregion
    }
}