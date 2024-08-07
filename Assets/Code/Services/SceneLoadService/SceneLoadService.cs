using System;
using System.Collections;
using Code.Infrastucture;
using Code.Infrastucture.GmaeStateMachine;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Services.SceneLoadService
{
    public class SceneLoadService : ISceneLoadService
    {
        private LoadingScreen _loadingScreen;
        private ICoroutineRunner _coroutineRunner;

        public SceneLoadService(ICoroutineRunner coroutineRunner, LoadingScreen loadingScreen)
        {
            _coroutineRunner = coroutineRunner;
            _loadingScreen = loadingScreen;
        }
        
        public void LoadScene(string sceneName, Action onLoad = null)
        {
            _loadingScreen.Show();
            _coroutineRunner.StartCoroutine(LoadSceneRoutine(sceneName, onLoad));
        }

        private IEnumerator LoadSceneRoutine(string sceneName, Action onLoad)
        {
            AsyncOperation loadingScene = SceneManager.LoadSceneAsync(sceneName);

            while (!loadingScene.isDone)
                yield return null;
            
            _loadingScreen.Hide();
            onLoad?.Invoke();
        }
    }
}