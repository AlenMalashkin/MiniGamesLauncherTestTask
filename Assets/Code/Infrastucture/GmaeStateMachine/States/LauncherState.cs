using Code.Data;
using Code.Infrastucture.Factories.WindowFactory;
using Code.Services.ProgressService;
using Code.Services.SaveLoadService;
using Code.Services.SceneLoadService;

namespace Code.Infrastucture.GmaeStateMachine.States
{
    public class LauncherState : IState
    {
        private ISceneLoadService _sceneLoadService;
        private IWindowFactory _windowFactory;
        private IProgressService _progressService;
        private ISaveLoadService _saveLoadService;

        public LauncherState(ISceneLoadService sceneLoadService, IWindowFactory windowFactory,
            IProgressService progressService, ISaveLoadService saveLoadService)
        {
            _sceneLoadService = sceneLoadService;
            _windowFactory = windowFactory;
            _progressService = progressService;
            _saveLoadService = saveLoadService;
        }

        public async void Enter()
        {
            _sceneLoadService.LoadScene("Launcher", OnLoad);
            _progressService.Progress = await _saveLoadService.LoadData() ?? new Progress();
        }

        public void Exit()
        {
        }

        private void OnLoad()
        {
            _windowFactory.CreateLauncherWindow();
        }
    }
}