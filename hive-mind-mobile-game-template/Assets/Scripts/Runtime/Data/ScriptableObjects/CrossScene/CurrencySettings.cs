using AYellowpaper.SerializedCollections;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Enums.CrossScene;
using UnityEngine;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.CrossScene
{
    [CreateAssetMenu(fileName = "CurrencySettings", menuName = "CodeCatGames/HiveMindMobileGameTemplate/CrossScene/CurrencySettings")]
    public sealed class CurrencySettings : ScriptableObject
    {
        #region Fields
        [Header("Currency Settings Fields")]
        [SerializeField] private SerializedDictionary<CurrencyTypes, int> defaultCurrencyValues;
        [SerializeField] private SerializedDictionary<CurrencyTypes, Sprite> currencyIcons;
        #endregion

        #region Getters
        public SerializedDictionary<CurrencyTypes, int> DefaultCurrencyValues => defaultCurrencyValues;
        public SerializedDictionary<CurrencyTypes, Sprite> CurrencyIcons => currencyIcons;
        #endregion
    }
}
