using Code.Games.Runner;

namespace Code.UI.Windows.Finish
{
    public class CurrentTimeViewer : TimeViewer
    {
        private Timer _timer;
        
        public void Init(Timer timer)
        {
            _timer = timer;
        }
        
        protected override string GetFormattedTimeToShow()
            => "Время прохождения: " + _timer.TickedTime;
    }
}