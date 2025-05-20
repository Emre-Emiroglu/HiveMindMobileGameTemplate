using System;
using System.Collections.Generic;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ValueObjects.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Enums.CrossScene;
using CodeCatGames.HMModelViewController.Runtime;
using CodeCatGames.HMPersistentData.Runtime;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.CrossScene
{
    public sealed class CurrencyModel : Model<CurrencySettings>
    {
        #region Fields
        private CurrencyPersistentData _currencyPersistentData;
        #endregion

        #region Getters
        public CurrencyPersistentData CurrencyPersistentData => _currencyPersistentData;
        #endregion

        #region Constructor
        public CurrencyModel(CurrencySettings settings) : base(settings)
        {
            _currencyPersistentData =
                new CurrencyPersistentData(new Dictionary<CurrencyTypes, int>(settings.DefaultCurrencyValues));

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
            Dictionary<CurrencyTypes, int> currencyValues = _currencyPersistentData.CurrencyValues;
            
            int lastValue = currencyValues[currencyType];
            
            currencyValues[currencyType] = isSet ? amount : lastValue + amount;

            SaveData();
        }
        public override void LoadData() => _currencyPersistentData =
            PersistentDataServiceUtilities.Load<CurrencyPersistentData>(nameof(_currencyPersistentData));
        public override void SaveData() =>
            PersistentDataServiceUtilities.Save(nameof(_currencyPersistentData), _currencyPersistentData);
        #endregion
    }
}