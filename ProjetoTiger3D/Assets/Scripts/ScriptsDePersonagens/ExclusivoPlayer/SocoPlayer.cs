using UnityEngine;

public class SocoPlayer : MonoBehaviour
{
    public PlayerNivel playerNivel;
    void OnTriggerEnter(Collider other)
    {
        VidaInimigo vidainimigo = other.GetComponent<VidaInimigo>();
        if (other.CompareTag("InimigoPreto") || other.CompareTag("InimigoVerde"))
        {
            if(vidainimigo != null)
            Debug.Log("Socou o inimigo preto ou verde");
            vidainimigo.TomarDano(playerNivel.numNivel);
        }
    }
}
