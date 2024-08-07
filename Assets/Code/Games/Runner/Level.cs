using UnityEngine;

namespace Code.Games.Runner
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private Transform _playerSpawnPoint;
        [SerializeField] private Transform _finishSpawnPoint;
        public Transform PlayerSpawnPoint => _playerSpawnPoint;
        public Transform FinishSpawnPoint => _finishSpawnPoint;

        private Timer _timer;
        
        public void Init(Timer timer)
        {
            _timer = timer;
        }
        
        private void Update()
        {
            _timer.Tick();
        }
    }
}