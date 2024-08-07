using System;
using System.IO;
using Code.Games;
using Code.Infrastucture.GmaeStateMachine;
using Code.Infrastucture.GmaeStateMachine.States;
using Code.Services.AssetBundleLoader;
using Code.Services.StaticDataService;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Windows.Launcher.Buttons
{
    public class SelectGameButton : ButtonBase
    {
        [SerializeField] private Button _enterGameButton;
        [SerializeField] private GameType _type;
        [SerializeField] private DownloadAssetsButton _downloadAssetsButton;
        [SerializeField] private DeleteAssetsButton _deleteAssetsButton;

        private IAssetBundleService _assetBundleService;
        private IGameStateMachine _gameStateMachine;
        private IStaticDataService _staticDataService;

        public void Init(IAssetBundleService assetBundleService, IGameStateMachine gameStateMachine,
            IStaticDataService staticDataService)
        {
            _assetBundleService = assetBundleService;
            _gameStateMachine = gameStateMachine;
            _staticDataService = staticDataService;
            
            _downloadAssetsButton.Init(_assetBundleService, _staticDataService);
            _deleteAssetsButton.Init(_assetBundleService, _staticDataService);
            
            _downloadAssetsButton.Subscribe();
            _deleteAssetsButton.Subscribe();
        }

        private void Start()
        {
            if (File.Exists(Application.streamingAssetsPath + _staticDataService.GetGameAssetsPaths(_type).LocalAssetBundlePath))
                _enterGameButton.interactable = true;
        }

        private void OnDisable()
        {
            _downloadAssetsButton.Unsubscribe();
            _deleteAssetsButton.Unsubscribe();
        }

        protected override void OnClick()
        {
            _gameStateMachine.Enter<GameState, GameType>(_type);
        }
    }
}