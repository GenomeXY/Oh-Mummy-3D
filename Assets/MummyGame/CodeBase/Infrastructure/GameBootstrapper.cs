using System;
using MummyGame.CodeBase.Services.Input;
using System.Collections;
using UnityEngine;

namespace MummyGame.CodeBase.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour
    {
        public static GameBootstrapper Instance { get; private set; }
        public static SceneLoader SceneLoader { get; private set; }
        public static IInputService InputService { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject); 
            }
            else
            {
                Destroy(gameObject);
            }
        }
        
        private IEnumerator Start()
        {
            InputService = CreateInputService();
            Debug.Log($"[Bootstrapper] Input Service initialized.");
            
            SceneLoader = new SceneLoader();
            yield return StartCoroutine(SceneLoader.LoadAsync(Constants.MainMenu));
            Debug.Log($"[Bootstrapper] Main menu loaded.");
        }
        
        private static IInputService CreateInputService()
        {
            if (Application.isEditor)
            {
                return new StandaloneInputService();
            }
            else
            {
                return new MobileInputService();
            }
        }
        
        public void StartGame()
        {
            Debug.Log("[Bootstrap] Starting game...");
            StartCoroutine(SceneLoader.LoadAsync(Constants.Level1));
        }
    }
}

