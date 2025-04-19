using UnityEngine;

public class InimigoPerseguir : MonoBehaviour
{
    Animator animator;
    public Transform player;
    public float velocidade = 2f;
    public float RotSpeed = 5f;

    public float tempoEntreAtaques = 1f;
    private float tempoAtaqueAtual;

    void Start()
    {
        animator = GetComponent<Animator>();
        tempoAtaqueAtual = 0f;
    }

    void Update()
    {
        tempoAtaqueAtual -= Time.deltaTime;
        Perseguir();
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
