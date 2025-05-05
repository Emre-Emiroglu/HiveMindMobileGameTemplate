using System;
using System.Collections.Generic;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Enums.CrossScene;
using CodeCatGames.HMModelViewController.Runtime;
using CodeCatGames.HMPersistentData.Runtime;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.CrossScene
{
    public sealed class CurrencyModel : Model<CurrencySettings>
    {
        #region Fields
        private Dictionary<CurrencyTypes, int> _currencyValues;
        #endregion

        #region Getters
        public Dictionary<CurrencyTypes, int> CurrencyValues => _currencyValues;
        #endregion

        #region Constructor
        public CurrencyModel(CurrencySettings settings) : base(settings)
        {
            _currencyValues = new Dictionary<CurrencyTypes, int>(settings.DefaultCurrencyValues);

            try
            {
                LoadData();
            }
            catch (Exception)
            {
                SaveData();
            }
        }
        #endregion
        
        #region Executes
        public void ChangeCurrencyValue(CurrencyTypes currencyType, int amount, bool isSet)
        {
            int lastValue = _currencyValues[currencyType];
            
            _currencyValues[currencyType] = isSet ? amount : lastValue + amount;

            SaveData();
        }
        public override void LoadData() => _currencyValues =
            PersistentDataServiceUtilities.Load<Dictionary<CurrencyTypes, int>>(nameof(_currencyValues));
        public override void SaveData() =>
            PersistentDataServiceUtilities.Save(nameof(_currencyValues), _currencyValues);
        #endregion
    }
}