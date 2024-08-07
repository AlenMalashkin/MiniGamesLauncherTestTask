using Code.Data;
using Code.Games;
using Code.Games.Runner;
using Code.Infrastucture.Factories.WindowFactory;
using Code.Services.AssetProvider;
using Code.Services.StaticDataService;
using UnityEngine;

namespace Code.Services.GameStarter
{
    public class RunnerGameStarter : IRunnerGameStarter
    {
        private Timer _timer;
        private IWindowFactory _windowFactory;
        private IAssetProvider _assetProvider;
        private IStaticDataService _staticDataService;

        public RunnerGameStarter(IWindowFactory windowFactory, IAssetProvider assetProvider,
            IStaticDataService staticDataService)
        {
            _windowFactory = windowFactory;
            _assetProvider = assetProvider;
            _staticDataService = staticDataService;
        }
        
        public void StartGame()
        {
            GameAssetsPaths gameAssetsPaths = _staticDataService.GetGameAssetsPaths(GameType.Runner);
            _timer = new Timer();
            _timer.SetTimerActive(true);
            GameObject levelPrefab = _assetProvider.LoadAsset<GameObject>("RunnerAssetBundle", "Environment");
            Level level = Object.Instantiate(levelPrefab).GetComponent<Level>();
            level.Init(_timer);
            GameObject playerPrefab = _assetProvider.LoadAsset<GameObject>("RunnerAssetBundle", "Player");
            Player player = Object.Instantiate(playerPrefab, level.PlayerSpawnPoint.position, Quaternion.identity)
                .GetComponent<Player>();
            GameObject finishTriggerPrefab = _assetProvider.LoadAsset<GameObject>("RunnerAssetBundle", "FinishTrigger");
            FinishTrigger finishTrigger = Object.Instantiate(finishTriggerPrefab, level.FinishSpawnPoint.position, 
                Quaternion.Euler(new Vector3(0, 180, 0))).GetComponent<FinishTrigger>();
            finishTrigger.Init(_timer, _windowFactory);
        }

        public void ExitGame()
        {
            _timer.SetTimerActive(false);
        }
    }
}