using TMPro;
using Unity.Mathematics;
using UnityEngine;
using System.Collections;
public class DialogoComTio : MonoBehaviour
{
    public TMP_Text mensagemTexto;
    public TMP_Text interagir;
    public GameObject painelInteracao;
    public Transform jogador;
    public float distanciaInteracao = 3f;
    public int casos = 1;

    private bool aff = false;
    private bool jogadorPerto = false;

    void Start()
    {
        painelInteracao.SetActive(false); 
        mensagemTexto.text = "";
        interagir.text = "";
    }

    void Update()
    {
        float distancia = Vector3.Distance(jogador.position, transform.position);
        jogadorPerto = distancia <= distanciaInteracao;
        if(jogadorPerto && aff==false)
        {
            interagir.text = "Pressione E para interagir!";
            if (Input.GetKeyDown(KeyCode.E))
            {
                switch (casos)
                {
                    case 1:
                        painelInteracao.SetActive(true);
                        mensagemTexto.text = "Tigor:\nOlá Tio, queria saber como se jogar isso aqui!";
                        Debug.Log("Tocando dialogo 1");
                        casos = 2; 
                        break;
                    case 2:
                        painelInteracao.SetActive(true);
                        mensagemTexto.text = "Tio:\nOlá sobrinho, você pode apertar shift para correr e E para atacar seus inimigos!\n(ou H para mutar essa música)";
                        Debug.Log("Tocando dialogo 2");
                        casos = 3;
                        break;
                    case 3:
                        painelInteracao.SetActive(true);
                        mensagemTexto.text = "Tigor:\nEntendi,valeu Tio!";
                        Debug.Log("Tocando dialogo 3");
                        casos = 4;
                        break;
                    case 4:
                        painelInteracao.SetActive(true);
                        mensagemTexto.text = "Tio:\nBoa sorte no resgate!";
                        Debug.Log("Tocando dialogo 4");
                        casos = 5;
                        break;
                    case 5:
                        painelInteracao.SetActive(false);
                        mensagemTexto.text = "";
                        aff = true;
                        if (aff)
                        {
                            StartCoroutine(EsperarEDepoisResetar());
                            
                        }
                        break;
                        
                }
            }
        }
    else
        {
            interagir.text = "";
            mensagemTexto.text = "";
            painelInteracao.SetActive(false);
        }
    }
    IEnumerator EsperarEDepoisResetar()
    {
        painelInteracao.SetActive(true);
        mensagemTexto.text = "";
        Debug.Log("Esperando 5 segundos...");

        yield return new WaitForSeconds(2f);

        painelInteracao.SetActive(false);
        mensagemTexto.text = "";
        casos = 1;
        aff = false;
        Debug.Log("Voltando pro caso 1");
    }
}
