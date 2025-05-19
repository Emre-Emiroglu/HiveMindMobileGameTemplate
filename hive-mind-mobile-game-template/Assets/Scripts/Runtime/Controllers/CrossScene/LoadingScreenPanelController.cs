using System;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Utilities.Extensions;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Views.CrossScene;
using CodeCatGames.HMModelViewController.Runtime;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Controllers.CrossScene
{
    public sealed class LoadingScreenPanelController : Controller<CrossSceneModel, CrossSceneSettings, LoadingScreenPanelView>
    {
        #region Fields
        private AsyncOperation _loadOperation;
        private bool _loadingCompleted;
        #endregion
        
        #region Constructor
        public LoadingScreenPanelController(CrossSceneModel model, LoadingScreenPanelView view) : base(model, view) { }
        #endregion
        
        #region Executes
        public override void Execute(params object[] parameters)
        {
            AsyncOperation asyncOperation = (AsyncOperation)parameters[0];
            bool isActive = (bool)parameters[1];
            
            ChangeLoadingScreenActivation(asyncOperation, isActive).Forget();
        }
        private async UniTaskVoid ChangeLoadingScreenActivation(AsyncOperation asyncOperation, bool isActive)
        {
            if (isActive)
            {
                ResetProgressBar();
                
                _loadOperation = asyncOperation;
                
                ChangePanelActivation(true);
                WaitUntilSceneIsLoaded();
            }
            else
            {
                await UniTask.WaitUntil(() => _loadingCompleted);
                
                ChangePanelActivation(false);
            }
        }
        private void ChangePanelActivation(bool isActive)
        {
            View.UIPanelVo.CanvasGroup.ChangeUIPanelCanvasGroupActivation(isActive);
        }
        private void ResetProgressBar()
        {
            View.FillImage.fillAmount = 0f;
            
            _loadOperation = null;
            _loadingCompleted = false;
        }
        private async void WaitUntilSceneIsLoaded()
        {
            try
            {
                while (!_loadOperation.isDone)
                {
                    float progress = _loadOperation.progress;
                    float targetProgress = _loadOperation.isDone ? 1f : progress;

                    // Lerp fill amount towards target progress
                    LerpProgressBar(targetProgress);

                    await UniTask.Yield();
                }

                //async operation finishes at 90%, lerp to full value for a while
                float time = 0.5f;
                while (time > 0)
                {
                    time -= Time.deltaTime;
                    // Lerp fill amount towards target progress
                    LerpProgressBar(1f);

                    await UniTask.Yield();
                }

                await UniTask.Yield();

                _loadingCompleted = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        private void LerpProgressBar(float targetProgress) => View.FillImage.fillAmount =
            Mathf.Lerp(View.FillImage.fillAmount, targetProgress, Time.unscaledDeltaTime * 10f);
        #endregion
    }
}