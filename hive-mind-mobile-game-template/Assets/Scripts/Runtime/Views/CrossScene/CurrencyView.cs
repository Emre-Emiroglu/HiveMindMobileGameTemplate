using System.Collections.Generic;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Enums.CrossScene;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Views.CrossScene
{
    public sealed class CurrencyView : View
    {
        #region Fields
        [Header("Currency View Fields")]
        [SerializeField] private Dictionary<CurrencyTypes, TextMeshProUGUI> _currencyTexts;
        [SerializeField] private Dictionary<CurrencyTypes, Button> _currencyButtons;
        #endregion

        #region Getters
        public Dictionary<CurrencyTypes, TextMeshProUGUI> CurrencyTexts => _currencyTexts;
        public Dictionary<CurrencyTypes, Button> CurrencyButtons => _currencyButtons;
        #endregion
    }
}