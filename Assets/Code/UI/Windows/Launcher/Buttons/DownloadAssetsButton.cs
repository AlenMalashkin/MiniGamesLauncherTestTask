using Code.Data;
using Code.Games;
using Code.Services;
using Code.Services.AssetBundleLoader;
using Code.Services.AssetProvider;
using Code.Services.StaticDataService;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Windows.Launcher.Buttons
{
    public class DownloadAssetsButton : ButtonBase
    {
        [SerializeField] private Button _playGameButton;
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
            LoadGameAssets();
        }
        
        private async void LoadGameAssets()
        {
            GameAssetsPaths gameAssetsPaths = _staticDataService.GetGameAssetsPaths(_type);
            await _assetBundleService.LoadAssetBundle(gameAssetsPaths.ServerAssetBundlePath, gameAssetsPaths.LocalAssetBundlePath);
            _playGameButton.interactable = true;
        }
    }
}