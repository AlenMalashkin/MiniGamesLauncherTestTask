using System.IO;
using System.Threading.Tasks;
using Firebase.Storage;
using UnityEngine;

namespace Code.Services.AssetBundleLoader
{
    public class AssetBundleService : IAssetBundleService
    {
        private FirebaseStorage _storage;
        private StorageReference _storageReference;

        public AssetBundleService()
        {
            _storage = FirebaseStorage.DefaultInstance;
        }

        public async Task LoadAssetBundle(string assetBundleServerPath, string assetBundleLocalPath)
        {
            _storageReference = _storage.RootReference.Child(assetBundleServerPath);

            if (!Directory.Exists(Application.streamingAssetsPath + "/AssetBundles"))
            {
                Directory.CreateDirectory(Application.streamingAssetsPath + "/AssetBundles");
            }

            string file = "file://" + Application.streamingAssetsPath + assetBundleLocalPath;
            await _storageReference.GetFileAsync(file).ContinueWith(task =>
            {
                if (task.IsCompleted)
                    Debug.Log("Downloaded");
            });
        }

        public void RemoveAssetBundle(string assetBundlePath)
        {
            File.Delete(Application.streamingAssetsPath + assetBundlePath);
        }
    }
}