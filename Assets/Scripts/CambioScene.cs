using Unity.VisualScripting;
using UnityEngine;

public class Cambiodeescenario : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            ResetScene reset =  new ResetScene();
            reset.RecargarEscena();
        }
    }
}
