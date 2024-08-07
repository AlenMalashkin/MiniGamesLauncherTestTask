using System.Threading.Tasks;

namespace Code.Services.AssetBundleLoader
{
    public interface IAssetBundleService : IService
    {
        Task LoadAssetBundle(string assetBundleServerPath, string assetBundleLocalPath);
        void RemoveAssetBundle(string assetBundlePath);
    }
}