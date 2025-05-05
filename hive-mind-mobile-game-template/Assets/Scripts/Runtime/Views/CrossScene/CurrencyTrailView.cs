using System;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ValueObjects.CrossScene;
using CodeCatGames.HMModelViewController.Runtime;
using CodeCatGames.HMPool.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Views.CrossScene
{
    public sealed class CurrencyTrailView : MonoPoolable, IView
    {
        #region Actions
        public event Action Created;
        public event Action GetFromPool;
        public event Action ReturnToPool;
        public event Action Destroyed;
        #endregion
        
        #region Fields
        [Header("Currency Trail View Fields")]
        [SerializeField] private Image iconImage;
        [SerializeField] private TextMeshProUGUI amountText;
        #endregion

        #region Getters
        public Image IconImage => iconImage;
        public TextMeshProUGUI AmountText => amountText;
        #endregion

        #region Properties
        public CurrencyTrailData CurrencyTrailData {get; set;}
        #endregion
        
        #region Core
        public override void OnCreated() => Created?.Invoke();
        public override void OnGetFromPool() => GetFromPool?.Invoke();
        public override void OnReturnToPool() => ReturnToPool?.Invoke();
        public override void OnDestroyed() => Destroyed?.Invoke();
        #endregion

        #region Executes
        public void Show() => gameObject.SetActive(true);
        public void Hide() => gameObject.SetActive(false);
        #endregion
    }
}