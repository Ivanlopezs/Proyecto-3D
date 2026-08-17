using System.Collections;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LoadingChanger : MonoBehaviour
{
    public string nextScene;
    public TMP_Text loadingText;
    private InputAction _nextScene;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _nextScene = InputSystem.actions.FindAction("Jump");
        LoadButton();
    }

    public void LoadButton()
    {
        StartCoroutine(LoadScene());
    }

    private IEnumerator LoadScene()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(nextScene);

        operation.allowSceneActivation = false;
        while(operation.progress < 0.9f)
        {
            float progressValue = operation.progress / 0.9f *100f;
            yield return new WaitForSeconds(1);
            loadingText.text = progressValue.ToString() + "%";
        }

        loadingText.text = (operation.progress / 0.9f *100f).ToString() + "%";

        yield return new WaitUntil(() => _nextScene.WasPressedThisFrame());
        operation.allowSceneActivation = true;
    }
}
