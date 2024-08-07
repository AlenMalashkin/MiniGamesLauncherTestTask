using System.Collections.Generic;
using Code.Data;
using UnityEngine;

namespace Code.StaticData.GameAssetsConfiguration
{
    [CreateAssetMenu(fileName = "GameAssetsPathsStaticData", menuName = "GameAssetsPaths", order = 1)]
    public class GameAssetsPathsStaticData : ScriptableObject
    {
        [SerializeField] private List<GameAssetsPaths> _gameAssetsPaths;
        public List<GameAssetsPaths> GameAssetsPaths => _gameAssetsPaths;
    }
}