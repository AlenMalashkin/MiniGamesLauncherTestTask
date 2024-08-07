namespace Code.Services.GameStarter
{
    public interface IGameStarter : IService
    {
        void StartGame();
        void ExitGame();
    }
}