using PrimeTween;
using UnityEngine;

namespace HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.Bootstrap
{
    [CreateAssetMenu(fileName = "BootstrapSettings",
        menuName = "HiveMindMobileGameTemplate/Bootstrap/BootstrapSettings")]
    public sealed class BootstrapSettings : ScriptableObject
    {
        #region Fields
        [Header("Bootstrap Settings Fields")]
        [SerializeField] private Sprite logoSprite;
        [SerializeField] private float sceneActivationDuration;
        [SerializeField] private TweenSettings<float> logoTweenSettings;
        #endregion

        #region Getters
        public Sprite LogoSprite => logoSprite;
        public float SceneActivationDuration => sceneActivationDuration;
        public TweenSettings<float> LogoTweenSettings => logoTweenSettings;
        #endregion
    }
}
