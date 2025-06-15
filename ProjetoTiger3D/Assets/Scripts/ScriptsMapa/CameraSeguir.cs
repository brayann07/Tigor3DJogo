using UnityEngine;

public class CameraSeguir : MonoBehaviour
{
    public Transform alvo;  // jogador
    public float distancia = 5f;
    public float altura = 2f;
    public float sensibilidade = 100f;

    private float anguloAtual = 0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
    void LateUpdate()
    {
        if (alvo == null) return;

        float mouseX = Input.GetAxis("Mouse X") * sensibilidade * Time.deltaTime;
        anguloAtual += mouseX;

        Quaternion rotacao = Quaternion.Euler(0f, anguloAtual, 0f);
        Vector3 direcao = rotacao * Vector3.back;

        Vector3 posDesejada = alvo.position + direcao * distancia + Vector3.up * altura;
        transform.position = posDesejada;

        transform.LookAt(alvo.position + Vector3.up * 1.5f);

        
        alvo.rotation = Quaternion.Euler(0f, anguloAtual, 0f);
    }
}
