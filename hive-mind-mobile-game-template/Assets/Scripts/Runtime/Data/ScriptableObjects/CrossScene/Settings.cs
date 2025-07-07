using AYellowpaper.SerializedCollections;
using HiveMindMobileGameTemplate.Runtime.Enums.CrossScene;
using UnityEngine;
using UnityEngine.Audio;

namespace HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.CrossScene
{
    [CreateAssetMenu(fileName = "Settings", menuName = "HiveMindMobileGameTemplate/CrossScene/Settings")]
    public sealed class Settings : ScriptableObject
    {
        #region Fields
        [Header("Settings Fields")]
        [SerializeField] private AudioMixer audioMixer;
        [SerializeField] private SerializedDictionary<MusicTypes, AudioClip> musics;
        [SerializeField] private SerializedDictionary<SoundTypes, AudioClip> sounds;
        #endregion

        #region Getters
        public AudioMixer AudioMixer => audioMixer;
        public SerializedDictionary<MusicTypes, AudioClip> Musics => musics;
        public SerializedDictionary<SoundTypes, AudioClip> Sounds => sounds;
        #endregion
    }
}
