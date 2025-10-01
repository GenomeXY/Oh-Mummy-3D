using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader 
{
    public IEnumerator LoadAsync(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        while (!asyncLoad.isDone)
        {
            float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f);
            Debug.Log($"[Scene Loader] Loading progress: {progress * 100}%");
            yield return null;
        }
    }
}
