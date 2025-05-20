using System;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ValueObjects.CrossScene;
using CodeCatGames.HMModelViewController.Runtime;
using CodeCatGames.HMPersistentData.Runtime;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.CrossScene
{
    public sealed class LevelModel : Model<LevelSettings>
    {
        #region Fields
        private LevelPersistentData _levelPersistentData;
        #endregion

        #region Getters
        public LevelPersistentData LevelPersistentData => _levelPersistentData;
        #endregion
        
        #region Constructor
        public LevelModel(LevelSettings settings) : base(settings)
        {
            _levelPersistentData = new LevelPersistentData(0);
            
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
        public void ChangeLevelIndex(bool isSet, int value)
        {
            _levelPersistentData.CurrentLevelIndex = isSet ? value : _levelPersistentData.CurrentLevelIndex + value;

            SaveData();
        }
        public override void LoadData() => _levelPersistentData =
            PersistentDataServiceUtilities.Load<LevelPersistentData>(nameof(_levelPersistentData));
        public override void SaveData() =>
            PersistentDataServiceUtilities.Save(nameof(_levelPersistentData), _levelPersistentData);
        #endregion
    }
}