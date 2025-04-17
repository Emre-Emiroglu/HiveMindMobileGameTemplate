using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Enums.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Utilities;
using UnityEngine;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.CrossScene
{
    [CreateAssetMenu(fileName = "CurrencySettings", menuName = "CodeCatGames.HiveMindMobileGameTemplate/CrossScene/CurrencySettings")]
    public sealed class CurrencySettings : ScriptableObject
    {
        #region Fields
        [Header("Currency Settings Fields")]
        [SerializeField] private SerializableDictionary<CurrencyTypes, int> defaultCurrencyValues;
        [SerializeField] private SerializableDictionary<CurrencyTypes, Sprite> currencyIcons;
        #endregion

        #region Getters
        public SerializableDictionary<CurrencyTypes, int> DefaultCurrencyValues => defaultCurrencyValues;
        public SerializableDictionary<CurrencyTypes, Sprite> CurrencyIcons => currencyIcons;
        #endregion
    }
}
