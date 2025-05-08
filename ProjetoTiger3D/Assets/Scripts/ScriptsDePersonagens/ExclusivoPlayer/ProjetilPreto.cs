using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Projetil : MonoBehaviour
{
    public float speed = 10f;
    public PlayerNivel playerNivel;
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        VidaInimigo scriptdeVidadoInimigo = other.GetComponent<VidaInimigo>();
        if (other.CompareTag("Inimigo"))
        {

            if(scriptdeVidadoInimigo != null){
                scriptdeVidadoInimigo.TomarDano(playerNivel.numNivel);
            }
            Destroy(gameObject);
        }

         if (other.CompareTag("InimigoVerde"))
        {
            if(scriptdeVidadoInimigo != null){
                scriptdeVidadoInimigo.TomarDano(playerNivel.numNivel);
            }
            Destroy(gameObject);
        }
    }
}
