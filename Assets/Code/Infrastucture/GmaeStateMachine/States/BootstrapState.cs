using Code.Infrastucture.Factories.WindowFactory;
using Code.Services;
using Code.Services.AssetBundleLoader;
using Code.Services.AssetProvider;
using Code.Services.GameStarter;
using Code.Services.ProgressService;
using Code.Services.SaveLoadService;
using Code.Services.SceneLoadService;
using Code.Services.ScoreCountService;
using Code.Services.StaticDataService;

namespace Code.Infrastucture.GmaeStateMachine.States
{
    public class BootstrapState : IState
    {
        private IGameStateMachine _gameStateMachine;
        private ServiceLocator _serviceLocator;
        private ISceneLoadService _sceneLoadService;

        public BootstrapState(IGameStateMachine gameStateMachine, ServiceLocator serviceLocator,
            ISceneLoadService sceneLoadService)
        {
            _gameStateMachine = gameStateMachine;
            _serviceLocator = serviceLocator;
            _sceneLoadService = sceneLoadService;

            RegisterServices();
        }

        public void Enter()
        {
            _sceneLoadService.LoadScene("Bootstrap", OnLoad);
        }

        public void Exit()
        {
        }

        private void OnLoad()
        {
            _gameStateMachine.Enter<LauncherState>();
        }

        private void RegisterServices()
        {
            _serviceLocator.RegisterService(_gameStateMachine);
            RegisterDataServices();
            _serviceLocator.RegisterService<IAssetBundleService>(new AssetBundleService());
            _serviceLocator.RegisterService<IAssetProvider>(new AssetProvider());
            RegisterStaticDataService();
            _serviceLocator.RegisterService<IWindowFactory>(new WindowFactory(
                _serviceLocator.Resolve<IStaticDataService>(),
                _serviceLocator.Resolve<IAssetBundleService>(),
                _serviceLocator.Resolve<IGameStateMachine>(), 
                _serviceLocator.Resolve<IProgressService>(),
                _serviceLocator.Resolve<ISaveLoadService>()));
            _serviceLocator.RegisterService<IScoreCountService>(new ScoreCountService(
                _serviceLocator.Resolve<IProgressService>(),
                _serviceLocator.Resolve<ISaveLoadService>()));
            _serviceLocator.RegisterService<IClickerGameStarter>(
                new ClickerGameStarter(_serviceLocator.Resolve<IScoreCountService>(),
                    _serviceLocator.Resolve<IAssetProvider>(), _serviceLocator.Resolve<IProgressService>()));
            _serviceLocator.RegisterService<IRunnerGameStarter>(
                new RunnerGameStarter(_serviceLocator.Resolve<IWindowFactory>(),
                    _serviceLocator.Resolve<IAssetProvider>(), _serviceLocator.Resolve<IStaticDataService>()));
        }

        private void RegisterStaticDataService()
        {
            IStaticDataService staticDataService = new StaticDataService();
            staticDataService.LoadStaticData();
            _serviceLocator.RegisterService(staticDataService);
        }

        private void RegisterDataServices()
        {
            IProgressService progressService = new ProgressService();
            ISaveLoadService saveLoadService = new SaveLoadService(progressService);
            _serviceLocator.RegisterService(progressService);
            _serviceLocator.RegisterService(saveLoadService);
        }
    }
}