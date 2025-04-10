using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dialogo : MonoBehaviour
{
    [System.Serializable]
    public class LinhaDeDialogo
    {
        public string nomeDoPersonagem;
        [TextArea(3, 10)]
        public string textoDaLinha;
    }

    public TextMeshProUGUI textoNomePersonagem;
    public TextMeshProUGUI textoDialogo;
    public GameObject painelDeDialogo;
    public Button botaoProximo;

    public List<LinhaDeDialogo> linhasDeDialogo;
    private int indiceLinhaAtual = 0;

    void Start()
    {
        painelDeDialogo.SetActive(false);
        botaoProximo.onClick.AddListener(ProximaLinha);
    }

    public void IniciarDialogo()
    {
        painelDeDialogo.SetActive(true);
        indiceLinhaAtual = 0;
        MostrarLinha();
    }

    void MostrarLinha()
    {
        if (indiceLinhaAtual < linhasDeDialogo.Count)
        {
            textoNomePersonagem.text = linhasDeDialogo[indiceLinhaAtual].nomeDoPersonagem;
            textoDialogo.text = linhasDeDialogo[indiceLinhaAtual].textoDaLinha;
        }
        else
        {
            EncerrarDialogo();
        }
    }

    public void ProximaLinha()
    {
        indiceLinhaAtual++;
        MostrarLinha();
    }

    void EncerrarDialogo()
    {
        painelDeDialogo.SetActive(false);
    }
}
