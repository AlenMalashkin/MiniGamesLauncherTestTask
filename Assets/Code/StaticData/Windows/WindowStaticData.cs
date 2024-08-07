using System.Collections.Generic;
using Code.Data;
using UnityEngine;

namespace Code.StaticData.Windows
{
    [CreateAssetMenu(fileName = "WindowsConfig", menuName = "Windows", order = 0)]
    public class WindowStaticData : ScriptableObject
    {
        [SerializeField] private List<WindowData> _windows;
        public List<WindowData> Windows => _windows;
    }
}