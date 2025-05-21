using System.Collections.Generic;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.Game;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.Game;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Views.Game;
using CodeCatGames.HMModelViewController.Runtime;
using UnityEngine;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Controllers.Game
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