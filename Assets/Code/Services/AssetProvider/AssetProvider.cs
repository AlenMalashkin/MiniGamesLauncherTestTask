using System.IO;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Code.Services.AssetProvider
{
    public class AssetProvider : IAssetProvider
    {
        public T LoadAsset<T>(string bundleName, string assetName) where T : Object
        {
            AssetBundle loadedAssetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath + "/AssetBundles/", bundleName));
            T loadedAsset = loadedAssetBundle.LoadAsset<T>(assetName);
            loadedAssetBundle.Unload(false);
            return loadedAsset;
        }
    }
}