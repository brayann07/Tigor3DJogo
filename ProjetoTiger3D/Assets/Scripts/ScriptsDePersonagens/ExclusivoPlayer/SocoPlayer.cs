using UnityEngine;

public class SocoPlayer : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    public PlayerNivel playerNivel;
    void OnTriggerEnter(Collider other)
    {
        VidaInimigo vidainimigo = other.GetComponent<VidaInimigo>();
        if (other.CompareTag("InimigoPreto") || other.CompareTag("InimigoVerde"))
        {
            if (vidainimigo != null)
                Debug.Log("Socou o inimigo preto ou verde");
            vidainimigo.TomarDano(playerNivel.numNivel);
        }
    }
}
