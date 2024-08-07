using System.Threading.Tasks;
using UnityEngine;

namespace Code.Services.AssetProvider
{
    public interface IAssetProvider : IService
    {
        T LoadAsset<T>(string bundleName, string assetName) where T : Object;
    }
}