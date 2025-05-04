using UnityEngine;

public class SocoPlayer : MonoBehaviour
{
    public PlayerNivel playerNivel;
    void OnTriggerEnter(Collider other)
    {
        VidaInimigo vidainimigo = other.GetComponent<VidaInimigo>();
        if (other.CompareTag("Inimigo"))
        {
            if(vidainimigo != null)
            Debug.Log("Socou o inimigo");
            vidainimigo.TomarDano(playerNivel.numNivel);
        }
    }
}
