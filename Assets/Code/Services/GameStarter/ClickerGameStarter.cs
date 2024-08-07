using Code.Games.Clicker;
using Code.Services.AssetProvider;
using Code.Services.ProgressService;
using Code.Services.ScoreCountService;
using UnityEngine;

namespace Code.Services.GameStarter
{
    public class ClickerGameStarter : IClickerGameStarter
    {
        private IScoreCountService _scoreCountService;
        private IAssetProvider _assetProvider;
        private IProgressService _progressService;

        private Transform _uiRoot;
        private ClickButton _clickButton;
        private ScoreViewer _scoreViewer;

        public ClickerGameStarter(IScoreCountService scoreCountService, IAssetProvider assetProvider,
            IProgressService progressService)
        {
            _scoreCountService = scoreCountService;
            _assetProvider = assetProvider;
            _progressService = progressService;
        }
        
        public void StartGame()
        {
            GameObject uiRootPrefab = _assetProvider.LoadAsset<GameObject>("ClickerAssetBundle", "UIRoot");
            GameObject uiRoot = Object.Instantiate(uiRootPrefab);
            Object.Instantiate(Resources.Load<GameObject>("Prefabs/Clicker/ClickerCamera"));
            Object.Instantiate(Resources.Load<GameObject>("Prefabs/Clicker/BackButton"), uiRoot.transform);
            GameObject clickButtonPrefab = _assetProvider.LoadAsset<GameObject>("ClickerAssetBundle", "ClickButton");
            _clickButton = Object.Instantiate(clickButtonPrefab, uiRoot.transform)
                .GetComponent<ClickButton>();
            GameObject scoreViewerPrefab = _assetProvider.LoadAsset<GameObject>("ClickerAssetBundle", "ScoreViewer");
            _scoreViewer = Object.Instantiate(scoreViewerPrefab, uiRoot.transform)
                .GetComponent<ScoreViewer>();
            _scoreViewer.Init(_progressService);
            
            _clickButton.Subscribe();
            _clickButton.Click += _scoreCountService.AddScore;
            _scoreCountService.ScoreChanged += _scoreViewer.ViewScore;
        }

        public void ExitGame()
        {
            _clickButton.Unsubscribe();
            _clickButton.Click -= _scoreCountService.AddScore;
            _scoreCountService.ScoreChanged -= _scoreViewer.ViewScore;
        }
    }
}