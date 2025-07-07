using HMModelViewController.Runtime;
using HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.MainMenu;
using HiveMindMobileGameTemplate.Runtime.Enums.CrossScene;
using HiveMindMobileGameTemplate.Runtime.Models.CrossScene;
using HiveMindMobileGameTemplate.Runtime.Models.MainMenu;
using HiveMindMobileGameTemplate.Runtime.Utilities.Extensions;
using HiveMindMobileGameTemplate.Runtime.Views.MainMenu;

namespace HiveMindMobileGameTemplate.Runtime.Controllers.MainMenu
{
    public sealed class StartPanelActivationController : Controller<MainMenuModel, MainMenuSettings, StartPanelView>
    {
        #region ReadonlyFields
        private readonly LevelModel _levelModel;
        #endregion
        
        #region Constructor
        public StartPanelActivationController(MainMenuModel model, StartPanelView view, LevelModel levelModel) :
            base(model, view) => _levelModel = levelModel;
        #endregion
        
        #region Executes
        public override void Execute(params object[] parameters)
        {
            UIPanelTypes uiPanelType = (UIPanelTypes) parameters[0];
            
            bool isShow = uiPanelType == View.UIPanelVo.UIPanelType;

            View.UIPanelVo.CanvasGroup.ChangeUIPanelCanvasGroupActivation(isShow);
            
            if (isShow)
                SetLevelText();
        }
        private void SetLevelText()
        {
            int levelNumber = _levelModel.LevelPersistentData.CurrentLevelIndex + 1;
            
            View.LevelText.SetText($"Level {levelNumber}");
        }
        #endregion
    }
}