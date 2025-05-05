using UnityEngine;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.Application
{
    [CreateAssetMenu(fileName = "ApplicationSettings", menuName = "CodeCatGames/HiveMindMobileGameTemplate/Application/ApplicationSettings")]
    public sealed class ApplicationSettings : ScriptableObject
    {
        #region Fields
        [Header("Application Settings Fields")]
        [Range(30, 240)][SerializeField] private int targetFrameRate;
        [SerializeField] private bool runInBackground;
        #endregion

        #region Getters
        public int TargetFrameRate => targetFrameRate;
        public bool RunInBackground => runInBackground;
        #endregion
    }
}
