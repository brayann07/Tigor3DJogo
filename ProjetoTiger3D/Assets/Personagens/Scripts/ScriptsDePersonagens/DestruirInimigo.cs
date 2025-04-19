using UnityEngine;

public class DestruirInimigo : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Inimigo"))
        {
            VidaInimigo1 vida = other.GetComponent<VidaInimigo1>();
            if (vida != null)
            {
                vida.TomarDano(1);
            }

        }
    }
}
