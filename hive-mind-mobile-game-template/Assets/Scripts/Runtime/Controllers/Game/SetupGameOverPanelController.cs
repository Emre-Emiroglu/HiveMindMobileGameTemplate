using System.Collections.Generic;
using HMModelViewController.Runtime;
using HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.Game;
using HiveMindMobileGameTemplate.Runtime.Models.Game;
using HiveMindMobileGameTemplate.Runtime.Views.Game;
using UnityEngine;

namespace HiveMindMobileGameTemplate.Runtime.Controllers.Game
{
    public sealed class SetupGameOverPanelController : Controller<GameModel, GameSettings, GameOverPanelView>
    {
        #region Constructor
        public SetupGameOverPanelController(GameModel model, GameOverPanelView view) : base(model, view) { }
        #endregion

        #region Executes
        public override void Execute(params object[] parameters)
        {
            bool isSuccess = (bool) parameters[0];
            
            foreach (KeyValuePair<bool, GameObject> item in View.GameOverPanels)
                item.Value.SetActive(item.Key == isSuccess);
        }
        #endregion
    }
}