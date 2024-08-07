using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Windows
{
    public abstract class ButtonBase : MonoBehaviour
    {
        [SerializeField] private Button _button;

        public void Subscribe()
            => _button.onClick.AddListener(OnClick);

        public void Unsubscribe()
            => _button.onClick.RemoveListener(OnClick);

        protected abstract void OnClick();
    }
}