using Code.Services.ProgressService;
using TMPro;
using UnityEngine;

namespace Code.Games.Clicker
{
    public class ScoreViewer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;

        private IProgressService _progressService;
        
        public void Init(IProgressService progressService)
        {
            _progressService = progressService;
        }
        
        private void Start()
        {
            ViewScore(_progressService.Progress.ClickCount);
        }

        public void ViewScore(int score)
            => _scoreText.text = "Score: " + score;
    }
}