using Code.Games.Runner;
using Code.Infrastucture.GmaeStateMachine;
using Code.Services.AssetBundleLoader;
using Code.Services.ProgressService;
using Code.Services.SaveLoadService;
using Code.Services.StaticDataService;
using Code.UI.Windows;
using Code.UI.Windows.Finish;
using Code.UI.Windows.Launcher;
using Object = UnityEngine.Object;

namespace Code.Infrastucture.Factories.WindowFactory
{
    public class WindowFactory : IWindowFactory
    {
        private IStaticDataService _staticDataService;
        private IAssetBundleService _assetBundleService;
        private IGameStateMachine _gameStateMachine;
        private IProgressService _progressService;
        private ISaveLoadService _saveLoadService;
        
        public WindowFactory(IStaticDataService staticDataService, IAssetBundleService assetBundleService,
            IGameStateMachine gameStateMachine, IProgressService progressService, ISaveLoadService saveLoadService)
        {
            _staticDataService = staticDataService;
            _assetBundleService = assetBundleService;
            _gameStateMachine = gameStateMachine;
            _progressService = progressService;
            _saveLoadService = saveLoadService;
        }

        public WindowBase CreateLauncherWindow()
        {
            LauncherWindow window =
                Object.Instantiate(_staticDataService.GetWindow(WindowType.LauncherWindow)) as LauncherWindow;
            window.Init(_assetBundleService, _gameStateMachine, _staticDataService);
            return window;
        }

        public FinishWindow CreateFinishWindow(Timer timer)
        {
            FinishWindow window =
                Object.Instantiate(_staticDataService.GetWindow(WindowType.FinishWindow)) as FinishWindow;
            window.Init(timer, _gameStateMachine, _progressService, _saveLoadService);
            return window;
        }
    }
}