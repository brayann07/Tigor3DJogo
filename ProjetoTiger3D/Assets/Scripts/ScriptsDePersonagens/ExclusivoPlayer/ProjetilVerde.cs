using Unity.VisualScripting;
using UnityEngine;

public class ProjetilVerde : MonoBehaviour
{
    public float speed = 10f;
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        VidaInimigo scriptdeVidadoInimigo = other.GetComponent<VidaInimigo>();
        if (other.CompareTag("InimigoPreto"))
        {
            if(scriptdeVidadoInimigo != null){
                Debug.Log("atingi o mago preto");
                scriptdeVidadoInimigo.TomarDano(1);
            }
            Destroy(gameObject);
        }
    
        if (other.CompareTag("Inimigo"))
        {
            if(scriptdeVidadoInimigo != null){
                scriptdeVidadoInimigo.TomarDano(1);
            }
            Destroy(gameObject);
        }
    }
}
