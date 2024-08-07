using Code.Data;
using Code.Games;
using Code.Infrastucture.Factories.WindowFactory;
using Code.UI.Windows;

namespace Code.Services.StaticDataService
{
    public interface IStaticDataService : IService
    {
        void LoadStaticData();
        WindowBase GetWindow(WindowType type);
        GameAssetsPaths GetGameAssetsPaths(GameType type);
    }
}