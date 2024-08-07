using Code.Infrastucture.GmaeStateMachine;
using Code.Infrastucture.GmaeStateMachine.States;
using Code.Services;
using Code.Services.SceneLoadService;
using UnityEngine;

namespace Code.Infrastucture
{
    public class Bootstrap : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] private LoadingScreen _loadingScreen;
        
        private IGameStateMachine _gameStateMachine;
        
        private void Awake()
        {
            _gameStateMachine = new GameStateMachine(ServiceLocator.Instance, new SceneLoadService(this, Instantiate(_loadingScreen)));
            _gameStateMachine.Enter<BootstrapState>();
            
            DontDestroyOnLoad(this);
        }
    }
}