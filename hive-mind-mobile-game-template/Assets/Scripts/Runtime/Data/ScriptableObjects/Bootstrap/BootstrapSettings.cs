using UnityEngine;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.Bootstrap
{
    [CreateAssetMenu(fileName = "BootstrapSettings", menuName = "CodeCatGames/HiveMindMobileGameTemplate/Bootstrap/BootstrapSettings")]
    public sealed class BootstrapSettings : ScriptableObject
    {
        #region Fields
        [Header("Bootstrap Settings Fields")]
        [SerializeField] private Sprite logoSprite;
        [SerializeField] private float sceneActivationDuration;
        #endregion

        #region Getters
        public Sprite LogoSprite => logoSprite;
        public float SceneActivationDuration => sceneActivationDuration;
        #endregion
    }
}
