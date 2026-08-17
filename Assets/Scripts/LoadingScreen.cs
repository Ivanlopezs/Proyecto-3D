using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class LoadingScreen : MonoBehaviour
{
    public TextMeshProUGUI LoadingText;
    public string MainScreen; 

    void Start()
    {
        StartCoroutine(CargarEscena());
    }

    IEnumerator CargarEscena()
    {
        AsyncOperation operacion = SceneManager.LoadSceneAsync(MainScreen);
    
        operacion.allowSceneActivation = false;

        while (!operacion.isDone)
        {
            float progreso = Mathf.Clamp01(operacion.progress / 0.9f);
            
            LoadingText.text = Mathf.RoundToInt(progreso * 100) + "%";

            if (operacion.progress >= 0.9f)
            {
                operacion.allowSceneActivation = true; 
            }

            yield return null; 
        }
    }
}