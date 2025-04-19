using UnityEngine;
using UnityEngine.UI;

public class VidaInimigo1 : MonoBehaviour
{
    public Image[] coracoes;  // Essa array aq a proposito serve pras imagens( poderia ter feito de um jeito mais facil)  
    private int contadorVida;

    void Start()
    {
        contadorVida = 3;
    }

    public void TomarDano(int dano)
    {
        contadorVida -= dano;

        if (contadorVida < 0)
            contadorVida = 0;

        for (int i = 0; i < coracoes.Length; i++)
        {
            coracoes[i].enabled = i < contadorVida;
        }

        if (contadorVida == 0)
        {
            Morrer();
        }
    }

    void Morrer()
    {
        Destroy(gameObject);
        //futuro transitions aq pra morrer
    }
}
