using System;
using Code.Games;
using Code.Services.GameStarter;
using Code.Services.SceneLoadService;

namespace Code.Infrastucture.GmaeStateMachine.States
{
    public class GameState : IPayloadState<GameType>
    {
        private IClickerGameStarter _clickerGameStarter;
        private IRunnerGameStarter _runnerGameStarter;
        private ISceneLoadService _sceneLoadService;

        private GameType _gameType;
        
        public GameState(IClickerGameStarter clickerGameStarter, IRunnerGameStarter runnerGameStarter, ISceneLoadService sceneLoadService)
        {
            _clickerGameStarter = clickerGameStarter;
            _runnerGameStarter = runnerGameStarter;
            _sceneLoadService = sceneLoadService;
        }
        
        public void Enter(GameType payload)
        {
            _sceneLoadService.LoadScene("Main", OnLoad);
            _gameType = payload;
        }

        public void Exit()
        {
            _clickerGameStarter.ExitGame();

            switch (_gameType)
            {
                case GameType.Clicker:
                    _clickerGameStarter.ExitGame();
                    break;
                case GameType.Runner:
                    _runnerGameStarter.ExitGame();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void OnLoad()
        {
            switch (_gameType)
            {
                case GameType.Clicker:
                    _clickerGameStarter.StartGame();
                    break;
                case GameType.Runner:
                    _runnerGameStarter.StartGame();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}