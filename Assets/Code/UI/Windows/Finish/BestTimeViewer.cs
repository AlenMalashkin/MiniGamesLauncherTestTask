using Code.Games.Runner;
using Code.Services.ProgressService;
using Code.Services.SaveLoadService;

namespace Code.UI.Windows.Finish
{
    public class BestTimeViewer : TimeViewer
    {
        private IProgressService _progressService;
        private ISaveLoadService _saveLoadService;
        private Timer _timer;

        public void Init(Timer timer, IProgressService progressService, ISaveLoadService saveLoadService)
        {
            _timer = timer;
            _progressService = progressService;
            _saveLoadService = saveLoadService;
        }

        protected override string GetFormattedTimeToShow()
        {
            if (_timer.TickedTime < _progressService.Progress.BestTime)
            {
                _progressService.Progress.BestTime = _timer.TickedTime;
                _saveLoadService.SaveData();
            }

            string record = "Рекордное время: " + _progressService.Progress.BestTime;
            return record;
        }
    }
}