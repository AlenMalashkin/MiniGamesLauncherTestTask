using TMPro;
using UnityEngine;

namespace Code.UI.Windows.Finish
{
    public abstract class TimeViewer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _timeText;
        
        private void Start()
        {
            _timeText.text = GetFormattedTimeToShow();
        }

        protected abstract string GetFormattedTimeToShow();
    }
}