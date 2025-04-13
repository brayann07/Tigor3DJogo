using TMPro;
using UnityEngine;

public class DialogoComTio : MonoBehaviour
{
    public TMP_Text mensagemTexto;
    public GameObject painelInteracao;
    public Transform jogador;
    public float distanciaInteracao = 3f;

    private bool jogadorPerto = false;
    private bool dialogoAtivo = false;

    void Start()
    {
        painelInteracao.SetActive(false); // Começa invisível
        mensagemTexto.text = "";
    }

    void Update()
    {
        float distancia = Vector3.Distance(jogador.position, transform.position);
        jogadorPerto = distancia <= distanciaInteracao;

        if (jogadorPerto)
        {
            painelInteracao.SetActive(true);

            if (!dialogoAtivo)
            {
                mensagemTexto.text = "Pressione E para interagir";
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!dialogoAtivo)
                {
                    mensagemTexto.text = "Olá! Esse é o começo de um diálogo...";
                    dialogoAtivo = true;
                }
                else
                {
                    // Fecha tudo ao apertar E novamente
                    painelInteracao.SetActive(false);
                    mensagemTexto.text = "";
                    dialogoAtivo = false;
                }
            }
        }
        else
        {
            // Saiu da área: esconde tudo
            painelInteracao.SetActive(false);
            mensagemTexto.text = "";
            dialogoAtivo = false;
        }
    }
}
