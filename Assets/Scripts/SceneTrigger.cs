using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrigger : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>() != null)
        {
            if (!string.IsNullOrWhiteSpace(sceneToLoad))
                SceneManager.LoadScene(sceneToLoad);
        }
    }
}
