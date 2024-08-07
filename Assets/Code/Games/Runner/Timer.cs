using UnityEngine;

namespace Code.Games.Runner
{
    public class Timer
    {
        public float TickedTime => _tickedTime;
        
        private float _tickedTime;
        private bool _active;

        public void SetTimerActive(bool active)
        {
            _tickedTime = 0;
            _active = active;
        }
        
        public void Tick()
        {
            if (!_active)
                return;
            
            _tickedTime += Time.deltaTime;
        }
    }
}