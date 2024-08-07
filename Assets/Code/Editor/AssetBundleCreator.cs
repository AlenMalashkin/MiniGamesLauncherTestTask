using UnityEditor;
using UnityEngine;

namespace Code.AssetManagement
{
    public class AssetBundleCreator
    {
        [MenuItem("Assets/Create Asset Bundles")]
        private static void BuildAssetBundles()
        {
            BuildPipeline.BuildAssetBundles(Application.dataPath + "/AssetBundles", BuildAssetBundleOptions.None,
                EditorUserBuildSettings.activeBuildTarget);
        }
    }
}