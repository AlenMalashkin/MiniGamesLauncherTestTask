using Code.Infrastucture.GmaeStateMachine;
using Code.Services.AssetBundleLoader;
using Code.Services.StaticDataService;
using Code.UI.Windows.Launcher.Buttons;
using UnityEngine;

namespace Code.UI.Windows.Launcher
{
    public class LauncherWindow : WindowBase
    {
        [SerializeField] private SelectGameButton _selectClickerButton;
        [SerializeField] private SelectGameButton _selectRunnerButton;

        public void Init(IAssetBundleService assetBundleService, IGameStateMachine gameStateMachine,
            IStaticDataService staticDataService)
        {
            _selectClickerButton.Init(assetBundleService, gameStateMachine, staticDataService);
            _selectRunnerButton.Init(assetBundleService, gameStateMachine, staticDataService);
            
            _selectClickerButton.Subscribe();
            _selectRunnerButton.Subscribe();
        }

        private void OnDisable()
        {
            _selectClickerButton.Unsubscribe();
            _selectRunnerButton.Unsubscribe();
        }
    }
}