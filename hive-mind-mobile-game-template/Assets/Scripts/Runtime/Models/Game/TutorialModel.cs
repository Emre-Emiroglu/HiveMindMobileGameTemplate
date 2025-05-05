using System;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.Game;
using CodeCatGames.HMModelViewController.Runtime;
using CodeCatGames.HMPersistentData.Runtime;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.Game
{
    public sealed class TutorialModel : Model<TutorialSettings>
    {
        #region Fields
        private bool _isTutorialShowed;
        #endregion

        #region Getters
        public bool IsTutorialShowed => _isTutorialShowed;
        #endregion
        
        #region Constructor
        public TutorialModel(TutorialSettings settings) : base(settings)
        {
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
            _isTutorialShowed = isTutorialShowed;
            
            SaveData();
        }
        public override void LoadData() =>
            _isTutorialShowed = PersistentDataServiceUtilities.Load<bool>(nameof(_isTutorialShowed));
        public override void SaveData() =>
            PersistentDataServiceUtilities.Save(nameof(_isTutorialShowed), _isTutorialShowed);
        #endregion
    }
}