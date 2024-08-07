using Code.Games.Runner;
using Code.Services;
using Code.UI.Windows;
using Code.UI.Windows.Finish;

namespace Code.Infrastucture.Factories.WindowFactory
{
    public interface IWindowFactory : IService
    {
        WindowBase CreateLauncherWindow();
        FinishWindow CreateFinishWindow(Timer timer);
    }
}