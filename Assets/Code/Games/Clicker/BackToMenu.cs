using Code.Infrastucture.GmaeStateMachine;
using Code.Infrastucture.GmaeStateMachine.States;
using Code.Services;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Games.Clicker
{
    public class BackToMenu : MonoBehaviour
    {
        [SerializeField] private Button _button;
        
        private IGameStateMachine _gameStateMachine;
        
        private void Awake()
        {
            _gameStateMachine = ServiceLocator.Instance.Resolve<IGameStateMachine>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(OnClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnClick);
        }

        private void OnClick()
        {
            _gameStateMachine.Enter<LauncherState>();
        }
    }
}