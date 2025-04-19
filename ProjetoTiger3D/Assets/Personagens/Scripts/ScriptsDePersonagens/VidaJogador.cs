using UnityEngine;
using UnityEngine.UI;

public class VidaJogador : MonoBehaviour
{
    public Image[] coracoes;
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
    }
}
