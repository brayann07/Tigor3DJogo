using UnityEngine;

public class SocoPlayer : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        VidaInimigo vidainimigo = other.GetComponent<VidaInimigo>();
        if (other.CompareTag("Inimigo"))
        {
            Debug.Log("Socou o inimigo");
            vidainimigo.TomarDano(1);
        }
    }
}
