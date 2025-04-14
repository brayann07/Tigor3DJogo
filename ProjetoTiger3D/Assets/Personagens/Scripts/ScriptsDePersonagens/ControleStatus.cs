using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Video;

public class ControleStatus : MonoBehaviour 
{
    public GameObject inimigo;
    public GameObject painel;
    public TMP_Text vida;
    public TMP_Text nivel;
    private int vidaPlayer = 3;
    private int nivelPlayer = 1;
    void Start()
    {
        painel.SetActive(true);
        AtualizarStatus();
    }
    void AtualizarStatus()
    {
        vida.text = "Vida: " + vidaPlayer;
        nivel.text = "Nível: " + nivelPlayer;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == inimigo)
        {
            vidaPlayer--;
            AtualizarStatus();
        }
    }
}
