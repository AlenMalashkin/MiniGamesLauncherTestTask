using System;
using Code.Games;

namespace Code.Data
{
    [Serializable]
    public class GameAssetsPaths
    {
        public GameType Type;
        public string ServerAssetBundlePath;
        public string LocalAssetBundlePath;
    }
}