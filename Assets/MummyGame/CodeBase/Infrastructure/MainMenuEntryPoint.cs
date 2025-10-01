using UnityEngine;
using UnityEngine.UI;

namespace MummyGame.CodeBase.Infrastructure
{
    public class MainMenuEntryPoint : MonoBehaviour
    {
        [SerializeField] private Button _startButton;
        
        private void OnEnable()
        {
            _startButton.onClick.AddListener(OnStartGame);
        }

        private void OnDisable()
        {
            _startButton.onClick.RemoveListener(OnStartGame);
        }
        
        private void Start()
        {
            // что-то тут будет инициализироваться при запуске меню
            Debug.Log("[MainMenu] Initialized and services loaded.");
        }
        
        private void OnStartGame()
        {
            GameBootstrapper.Instance.StartGame();
        }
    }
}