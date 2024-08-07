using System.Collections.Generic;
using System.Linq;
using Code.Data;
using Code.Games;
using Code.Infrastucture.Factories.WindowFactory;
using Code.StaticData.GameAssetsConfiguration;
using Code.StaticData.Windows;
using Code.UI.Windows;
using UnityEngine;

namespace Code.Services.StaticDataService
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<WindowType, WindowBase> _windowsStaticData = new Dictionary<WindowType, WindowBase>();
        private Dictionary<GameType, GameAssetsPaths> _gameAssetsPaths = new Dictionary<GameType, GameAssetsPaths>();

        public void LoadStaticData()
        {
            SetupWindowStaticData();
            SetupGameAssetsPaths();
        }

        public WindowBase GetWindow(WindowType type)
            => _windowsStaticData[type];

        public GameAssetsPaths GetGameAssetsPaths(GameType type)
            => _gameAssetsPaths[type]; 
        
        private void SetupWindowStaticData()
        {
            WindowStaticData windowStaticData = Resources.Load<WindowStaticData>("StaticData/Windows/WindowsConfig");

            LoadWindowsFromResources(windowStaticData);

            _windowsStaticData = windowStaticData
                .Windows.ToDictionary(x => x.Type, x => x.WindowBase);
        }

        private void LoadWindowsFromResources(WindowStaticData windowStaticData)
        {
            foreach (var windowBase in Resources.LoadAll<WindowBase>("Prefabs/Windows"))
            {
                WindowData windowData = new WindowData
                {
                    Type = windowBase.Type,
                    WindowBase = windowBase
                };
                windowStaticData.Windows.Add(windowData);
            }
        }

        private void SetupGameAssetsPaths()
        {
            _gameAssetsPaths = Resources.Load<GameAssetsPathsStaticData>("StaticData/GameAssetPaths/GameAssetsPathsStaticData")
                .GameAssetsPaths
                .ToDictionary(x => x.Type);
        }
    }
}