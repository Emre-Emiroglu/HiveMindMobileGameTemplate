using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Enums.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Utilities;
using UnityEngine;
using UnityEngine.Audio;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.CrossScene
{
    [CreateAssetMenu(fileName = "AudioSettings", menuName = "CodeCatGames.HiveMindMobileGameTemplate/CrossScene/AudioSettings")]
    public sealed class AudioSettings : ScriptableObject
    {
        #region Fields
        [Header("Audio Settings Fields")]
        [SerializeField] private AudioMixer audioMixer;
        [SerializeField] private SerializableDictionary<MusicTypes, AudioClip> musics;
        [SerializeField] private SerializableDictionary<SoundTypes, AudioClip> sounds;
        #endregion

        #region Getters
        public AudioMixer AudioMixer => audioMixer;
        public SerializableDictionary<MusicTypes, AudioClip> Musics => musics;
        public SerializableDictionary<SoundTypes, AudioClip> Sounds => sounds;
        #endregion
    }
}
