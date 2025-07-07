using HMModelViewController.Runtime;
using HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.Game;
using HiveMindMobileGameTemplate.Runtime.Enums.CrossScene;
using HiveMindMobileGameTemplate.Runtime.Models.Game;
using HiveMindMobileGameTemplate.Runtime.Utilities.Extensions;
using HiveMindMobileGameTemplate.Runtime.Views.Game;

namespace HiveMindMobileGameTemplate.Runtime.Controllers.Game
{
    public sealed class GameOverPanelActivationController : Controller<GameModel, GameSettings, GameOverPanelView>
    {
        #region Constructor
        public GameOverPanelActivationController(GameModel model, GameOverPanelView view) : base(model, view) { }
        #endregion

        #region Executes
        public override void Execute(params object[] parameters)
        {
            UIPanelTypes uiPanelType = (UIPanelTypes) parameters[0];

            View.UIPanelVo.CanvasGroup.ChangeUIPanelCanvasGroupActivation(uiPanelType == View.UIPanelVo.UIPanelType);
        }
        #endregion
    }
}