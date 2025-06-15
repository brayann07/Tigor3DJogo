using Unity.VisualScripting;
using UnityEngine;

public class ProjetilVerde : MonoBehaviour
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
        BossIA bossIA = other.GetComponent<BossIA>();
        if (other.CompareTag("InimigoPreto"))
        {
            if (scriptdeVidadoInimigo != null)
            {
                Debug.Log("atingi o mago preto");
                scriptdeVidadoInimigo.TomarDano(playerNivel.numNivel);
            }
            Destroy(gameObject);
        }

        if (other.CompareTag("Inimigo"))
        {
            if (scriptdeVidadoInimigo != null)
            {
                scriptdeVidadoInimigo.TomarDano(playerNivel.numNivel);
            }
            Destroy(gameObject);
        }
          if (other.CompareTag("Boss"))
        {
            if (bossIA != null)
            {
                bossIA.numDevidas -= playerNivel.numNivel;
                Debug.Log("tirei vida correspondente ao nivel");
            }
        }
    }
}
