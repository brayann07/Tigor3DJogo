using UnityEngine;

public class DestruirInimigo : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Inimigo"))
        {
            Destroy(other.gameObject); 
            Destroy(gameObject);        
        }
    }
}
