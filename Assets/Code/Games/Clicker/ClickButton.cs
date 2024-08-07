using System;
using Code.UI.Windows;
using UnityEngine;

namespace Code.Games.Clicker
{
    public class ClickButton : ButtonBase
    {
        public event Action<int> Click;

        [SerializeField] private int _scoreCountPerClick = 1;
        
        protected override void OnClick()
            => Click?.Invoke(_scoreCountPerClick);
    }
}