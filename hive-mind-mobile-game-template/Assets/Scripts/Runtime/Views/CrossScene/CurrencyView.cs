using AYellowpaper.SerializedCollections;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Enums.CrossScene;
using CodeCatGames.HMModelViewController.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Views.CrossScene
{
    public sealed class CurrencyView : View
    {
        #region Fields
        [Header("Currency View Fields")]
        [SerializeField] private SerializedDictionary<CurrencyTypes, TextMeshProUGUI> currencyTexts;
        [SerializeField] private SerializedDictionary<CurrencyTypes, Button> currencyButtons;
        #endregion

        #region Getters
        public SerializedDictionary<CurrencyTypes, TextMeshProUGUI> CurrencyTexts => currencyTexts;
        public SerializedDictionary<CurrencyTypes, Button> CurrencyButtons => currencyButtons;
        #endregion
    }
}