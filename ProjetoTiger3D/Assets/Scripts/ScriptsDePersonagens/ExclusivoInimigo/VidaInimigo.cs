using UnityEngine;
using UnityEngine.UI;

public class VidaInimigo : MonoBehaviour
{
    public Image[] coracoesVerde;  // Essa array aq a proposito serve pras imagens( poderia ter feito de um jeito mais facil)  
    public Image[] coracoesVermelho;
    private int contadorVida;
    public GameObject explosaoParticulas;
    public AudioSource explosaoAudio;
    void Start()
    {
        contadorVida = 3;
         for (int i = 0; i < coracoesVerde.Length; i++)
        {
            coracoesVerde[i].enabled = true;
            coracoesVermelho[i].enabled = false;
        }
    }

    public void TomarDano(int dano)
    {
        contadorVida -= dano;

        if (contadorVida < 0)
            contadorVida = 0;

        for (int i = 0; i < coracoesVerde.Length; i++)
        {
            coracoesVerde[i].enabled = i < contadorVida;
            coracoesVermelho[i].enabled = i >= contadorVida;
        }

        if (contadorVida == 0)
        {
            Morrer();
        }
    }

    void Morrer()
    {
         if (explosaoParticulas != null)
        {
            explosaoAudio.Play(); // som tocou!
           /*  Destroy(explosaoParticulas,3f); // unity nao deixa eu deleta isso KKKKKKKKK */
            Instantiate(explosaoParticulas, transform.position, Quaternion.identity); // so pra explodir no transform do inimigo msm 
        }
        Destroy(gameObject);
        //futuro transitions aq pra morrer
    }
}