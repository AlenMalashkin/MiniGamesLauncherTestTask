using System;
using Code.Games.Runner;
using Code.Infrastucture.GmaeStateMachine;
using Code.Infrastucture.GmaeStateMachine.States;
using Code.Services.ProgressService;
using Code.Services.SaveLoadService;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Windows.Finish
{
    public class FinishWindow : WindowBase
    {
        [SerializeField] private Button _backToLauncher;
        [SerializeField] private CurrentTimeViewer _currentTimeViewer;
        [SerializeField] private BestTimeViewer _bestTimeViewer;
        
        private IGameStateMachine _gameStateMachine;

        public void Init(Timer timer, IGameStateMachine gameStateMachine, IProgressService progressService,
            ISaveLoadService saveLoadService)
        {
            _gameStateMachine = gameStateMachine;
            _currentTimeViewer.Init(timer);
            _bestTimeViewer.Init(timer, progressService, saveLoadService);
        }

        private void Start()
        {
            _backToLauncher.onClick.AddListener(OnBackToLauncherClick);
        }

        private void OnDisable()
        {
            _backToLauncher.onClick.RemoveListener(OnBackToLauncherClick);
        }

        private void OnBackToLauncherClick()
        {
            _gameStateMachine.Enter<LauncherState>();
        }
    }
}