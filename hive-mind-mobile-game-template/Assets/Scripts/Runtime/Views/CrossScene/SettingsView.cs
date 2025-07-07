using AYellowpaper.SerializedCollections;
using HMModelViewController.Runtime;
using HiveMindMobileGameTemplate.Runtime.Enums.CrossScene;
using UnityEngine;
using UnityEngine.UI;

namespace HiveMindMobileGameTemplate.Runtime.Views.CrossScene
{
    public sealed class SettingsView : View
    {
        #region Fields
        [Header("Settings View Fields")]
        [SerializeField] private GameObject verticalGroup;
        [SerializeField] private Button button;
        [SerializeField] private Button exitButton;
        [SerializeField] private SerializedDictionary<SettingsTypes, Button> settingsButtons;
        [SerializeField] private SerializedDictionary<SettingsTypes, GameObject> settingsOnImages;
        [SerializeField] private SerializedDictionary<SettingsTypes, GameObject> settingsOffImages;
        #endregion

        #region Getters
        public GameObject VerticalGroup => verticalGroup;
        public Button Button => button;
        public Button ExitButton => exitButton;
        public SerializedDictionary<SettingsTypes, Button> SettingsButtons => settingsButtons;
        public SerializedDictionary<SettingsTypes, GameObject> SettingsOnImages => settingsOnImages;
        public SerializedDictionary<SettingsTypes, GameObject> SettingsOffImages => settingsOffImages;
        #endregion
    }
}