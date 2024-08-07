using System;
using Code.Services.ProgressService;
using Code.Services.SaveLoadService;

namespace Code.Services.ScoreCountService
{
    public class ScoreCountService : IScoreCountService
    {
        public event Action<int> ScoreChanged;
        
        private IProgressService _progressService;
        private ISaveLoadService _saveLoadService;

        public ScoreCountService(IProgressService progressService, ISaveLoadService saveLoadService)
        {
            _progressService = progressService;
            _saveLoadService = saveLoadService;
        }

        public void AddScore(int score)
        {
            _progressService.Progress.ClickCount += score;
            ScoreChanged?.Invoke(_progressService.Progress.ClickCount);
            _saveLoadService.SaveData();
        }
    }
}