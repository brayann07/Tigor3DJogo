using UnityEngine;

public class CameraSeguir : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 5, -10);
    public float sensibilidadedomouse = 3f;
    public float suavilidade = 0.1f;

    private Vector2 rotacaoAtual;
    private Vector3 posicaoAtualVelocidade;

    void LateUpdate() // a gente n usa update pq é a cada frame 
    {
        rotacaoAtual.x += Input.GetAxis("Mouse X") * sensibilidadedomouse;
        rotacaoAtual.y -= Input.GetAxis("Mouse Y") * sensibilidadedomouse;
        rotacaoAtual.y = Mathf.Clamp(rotacaoAtual.y, -30f, 60f); // pra limitar a camera!

        Quaternion rotacao = Quaternion.Euler(rotacaoAtual.y, rotacaoAtual.x, 0);
        Vector3 posicaoDesejada = target.position + rotacao * offset;

        transform.position = Vector3.SmoothDamp(transform.position, posicaoDesejada, ref posicaoAtualVelocidade, suavilidade);
        transform.LookAt(target);
    }
}
