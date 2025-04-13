using UnityEngine;
using UnityEngine.UIElements;
public class InimigoRPG : MonoBehaviour
{
    public Transform posicaodojogador;
    public float speed = 5f;
    public float RangeDeSeguir = 10f;
    private bool seAtacado;
    private Vector3 posicaooriginal;
    Vector3 direcao;
    public float Gravidade = 3f;
    void Start()
    {
        posicaooriginal = new Vector3(1031, 1, 164);
    }
void Update()
    {
       
        float distancia = Vector3.Distance(transform.position, posicaodojogador.position);
        if(distancia < RangeDeSeguir)
        {

            direcao = Vector3.MoveTowards(transform.position, posicaodojogador.position, speed * Time.deltaTime);
        }
        else
        {
            direcao = Vector3.MoveTowards(transform.position, posicaooriginal, speed * Time.deltaTime);
        }
        transform.position = direcao;
        direcao.y -= Gravidade * Time.deltaTime;
    }
}
