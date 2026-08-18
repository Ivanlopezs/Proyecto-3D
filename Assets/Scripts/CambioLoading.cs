using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioLoading : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            SceneManager.LoadScene("LoadScreen", LoadSceneMode.Single);
        }
    }


}
