using Code.Infrastucture.Factories.WindowFactory;
using UnityEngine;

namespace Code.Games.Runner
{
    public class FinishTrigger : MonoBehaviour
    {
        private IWindowFactory _windowFactory;
        private Timer _timer;
        
        public void Init(Timer timer, IWindowFactory windowFactory)
        {
            _timer = timer;
            _windowFactory = windowFactory;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Player player))
                FinishGame();
        }

        private void FinishGame()
        {
            _windowFactory.CreateFinishWindow(_timer);
        }
    }
}