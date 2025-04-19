using UnityEngine;

public class InimigoPerseguir : MonoBehaviour
{
    Animator animator;
    public Transform player;
    public float velocidade = 3f;
    public float RotSpeed = 5f;
    public float rangePerseguir = 10f;
    public float tempoEntreAtaques = 1f;
    private float tempoAtaqueAtual = 0f;

    private Vector3 posicaoOriginal;

    void Start()
    {
        animator = GetComponent<Animator>();
        posicaoOriginal = transform.position;
    }

    void Update()
    {
        float distancia = Vector3.Distance(transform.position, player.position);
        if (distancia < rangePerseguir)
        {
            Perseguir();
        }
        else
        {
            VoltarPosicaoOriginal();
        }
    }

    void Perseguir()
    {
        Vector3 direction = player.position - transform.position;
        direction.y = 0;

        if (direction.magnitude > 0.1f)
        {
            Quaternion rot = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, RotSpeed * Time.deltaTime);
            transform.position += transform.forward * velocidade * Time.deltaTime;
            animator.SetInteger("transitions", 2); 
        }
    }

    void VoltarPosicaoOriginal()
    {
        Vector3 direction = posicaoOriginal - transform.position;
        direction.y = 0;

        if (direction.magnitude > 0.1f)
        {
            Quaternion rot = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, RotSpeed * Time.deltaTime);
            transform.position += transform.forward * velocidade * Time.deltaTime;
            animator.SetInteger("transitions", 2); // andando
        }
        else
        {
            animator.SetInteger("transitions", 1); // idle
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && tempoAtaqueAtual <= 0f)
        {
            animator.SetInteger("transitions", 3);
            VidaJogador vida = other.GetComponent<VidaJogador>();
            if (vida != null)
            {
                vida.TomarDano(1);
                tempoAtaqueAtual = tempoEntreAtaques;
            }
        }
    }

 }







