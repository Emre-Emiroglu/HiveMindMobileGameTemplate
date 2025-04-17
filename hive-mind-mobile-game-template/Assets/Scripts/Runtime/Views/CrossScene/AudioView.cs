using System.Collections.Generic;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Enums.CrossScene;
using UnityEngine;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Views.CrossScene
{
    public sealed class AudioView : View
    {
        #region Fields
        [Header("Audio View Fields")]
        [SerializeField] private Dictionary<AudioTypes, AudioSource> _audioSources;
        #endregion

        #region Getters
        public Dictionary<AudioTypes, AudioSource> AudioSources => _audioSources;
        #endregion
    }
}