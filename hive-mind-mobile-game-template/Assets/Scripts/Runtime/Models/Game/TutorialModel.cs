using System;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.Game;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ValueObjects.Game;
using CodeCatGames.HMModelViewController.Runtime;
using CodeCatGames.HMPersistentData.Runtime;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.Game
{
    public sealed class TutorialModel : Model<TutorialSettings>
    {
        #region Fields
        private TutorialPersistentData _tutorialPersistentData;
        #endregion

        #region Getters
        public TutorialPersistentData TutorialPersistentData => _tutorialPersistentData;
        #endregion
        
        #region Constructor
        public TutorialModel(TutorialSettings settings) : base(settings)
        {
            _tutorialPersistentData = new TutorialPersistentData(false);
            
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
        public void SetIsTutorialShowed(bool isTutorialShowed)
        {
            _tutorialPersistentData.IsTutorialShowed = isTutorialShowed;
            
            SaveData();
        }
        public override void LoadData() => _tutorialPersistentData =
            PersistentDataServiceUtilities.Load<TutorialPersistentData>(nameof(_tutorialPersistentData));
        public override void SaveData() =>
            PersistentDataServiceUtilities.Save(nameof(_tutorialPersistentData), _tutorialPersistentData);
        #endregion
    }
}