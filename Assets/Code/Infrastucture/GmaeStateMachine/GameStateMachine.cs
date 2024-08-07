using System;
using System.Collections.Generic;
using Code.Infrastucture.Factories.WindowFactory;
using Code.Infrastucture.GmaeStateMachine.States;
using Code.Services;
using Code.Services.GameStarter;
using Code.Services.ProgressService;
using Code.Services.SaveLoadService;
using Code.Services.SceneLoadService;

namespace Code.Infrastucture.GmaeStateMachine
{
    public class GameStateMachine : IGameStateMachine
    {
        private Dictionary<Type, IExitableState> _states = new Dictionary<Type, IExitableState>();
        private IExitableState _currentState;

        public GameStateMachine(ServiceLocator serviceLocator, ISceneLoadService sceneLoadService)
        {
            _states[typeof(BootstrapState)] = new BootstrapState(this, serviceLocator, sceneLoadService);
            _states[typeof(LauncherState)] =
                new LauncherState(sceneLoadService, serviceLocator.Resolve<IWindowFactory>(),
                    serviceLocator.Resolve<IProgressService>(), 
                    serviceLocator.Resolve<ISaveLoadService>());
            _states[typeof(GameState)] = new GameState(serviceLocator.Resolve<IClickerGameStarter>(),
                serviceLocator.Resolve<IRunnerGameStarter>(), sceneLoadService);
        }

        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>
        {
            TState payloadState = GetState<TState>();
            payloadState.Enter(payload);
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _currentState?.Exit();

            TState state = GetState<TState>();
            _currentState = state;

            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState
            => _states[typeof(TState)] as TState;
    }
}