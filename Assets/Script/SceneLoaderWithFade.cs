using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneLoaderWithFade : MonoBehaviour
{
    [Header("Cena para carregar")]
    public LoadMode loadMode = LoadMode.NextInBuildIndex;
    public int sceneIndex = 0;
    public string sceneName = "";

    [Header("Auto Load")]
    public bool autoSkipAfterDelay = true;
    public float autoSkipDelay = 5f;

    [Header("Fade")]
    public CanvasGroup fadeGroup;
    public float fadeDuration = 1.5f;

    public enum LoadMode
    {
        NextInBuildIndex,
        ByIndex,
        ByName
    }

    void Start()
    {
        if (fadeGroup != null)
        {
            fadeGroup.alpha = 0f;
        }

        if (autoSkipAfterDelay)
        {
            Invoke(nameof(StartFadeAndLoad), autoSkipDelay);
        }
    }

    public void StartFadeAndLoad()
    {
        StartCoroutine(FadeAndLoad());
    }

    IEnumerator FadeAndLoad()
    {
    float t = 0f;

    if (fadeGroup != null)
    {
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            fadeGroup.alpha = Mathf.Lerp(0f, 1f, t / fadeDuration);
            yield return null;
        }

        fadeGroup.alpha = 1f;
    }

    // Aqui segue com o carregamento da cena
    switch (loadMode)
    {
        case LoadMode.NextInBuildIndex:
            LoadNextScene();
            break;
        case LoadMode.ByIndex:
            LoadSceneByIndex(sceneIndex);
            break;
        case LoadMode.ByName:
            LoadSceneByName(sceneName);
            break;
    }

    }

    void LoadNextScene()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int nextIndex = currentIndex + 1;
        SceneManager.LoadScene(nextIndex);
    }

    void LoadSceneByIndex(int index)
    {
        SceneManager.LoadScene(index);
    }

    void LoadSceneByName(string name)
    {
        SceneManager.LoadScene(name);
    }


    






}
