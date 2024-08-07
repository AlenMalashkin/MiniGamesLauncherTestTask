using System;

namespace Code.Services.ScoreCountService
{
    public interface IScoreCountService : IService
    {
        event Action<int> ScoreChanged;
        void AddScore(int score);
    }
}