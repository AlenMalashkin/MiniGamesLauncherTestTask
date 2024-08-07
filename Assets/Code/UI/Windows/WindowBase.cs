using Code.Infrastucture.Factories.WindowFactory;
using UnityEngine;

namespace Code.UI.Windows
{
    public abstract class WindowBase : MonoBehaviour
    {
        [SerializeField] private WindowType _type;
        public WindowType Type => _type;
    }
}