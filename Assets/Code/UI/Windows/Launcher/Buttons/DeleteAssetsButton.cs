using Code.Data;
using Code.Games;
using Code.Services.AssetBundleLoader;
using Code.Services.StaticDataService;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Windows.Launcher.Buttons
{
    public class DeleteAssetsButton : ButtonBase
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private GameType _type;
        
        private IAssetBundleService _assetBundleService;
        private IStaticDataService _staticDataService;

        public void Init(IAssetBundleService assetBundleService, IStaticDataService staticDataService)
        {
            _assetBundleService = assetBundleService;
            _staticDataService = staticDataService;
        }
        
        protected override void OnClick()
        {
            RemoveGameAssets();
        }

        private void RemoveGameAssets()
        {
            GameAssetsPaths gameAssetsPaths = _staticDataService.GetGameAssetsPaths(_type);
            _assetBundleService.RemoveAssetBundle(gameAssetsPaths.LocalAssetBundlePath);
            _playButton.interactable = false;
        }
    }
}