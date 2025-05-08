using UnityEngine;

public class VidaAnimacao : MonoBehaviour
{
    public float velocidade = 5f;

    private Vector3 rotacaoDireita;
    private Vector3 rotacaoAtual;
    private Vector3 rotacaoEsquerda;

    void Start()
    {
        rotacaoAtual = transform.localEulerAngles;
        rotacaoDireita = rotacaoAtual + new Vector3(0, 0, 15);
        rotacaoEsquerda = rotacaoAtual + new Vector3(0, 0, -15);
    }

    void Update()
    {
        float anguloZ = Mathf.Sin(Time.time * velocidade) * 10f;
        transform.localRotation = Quaternion.Euler(rotacaoAtual + new Vector3(0, 0, anguloZ));
    }
}
