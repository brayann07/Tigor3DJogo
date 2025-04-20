using UnityEngine;

public class MagiaSaindo : MonoBehaviour
{
    public GameObject esferaVerde;
    public Transform ondevaisairabola;
    private float bolaVelocidade = 10f;
    private float tempoDeVida = 2f;
    private Animator anim;
    private Camera mainCamera;

    void Start()
    {
        anim = GetComponent<Animator>();
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            anim.SetInteger("transitions", 3);
            JogarABola();
        }
    }

    void JogarABola()
    {
        // Raycast do mouse para o mundo
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Vector3 direcao;
        if (Physics.Raycast(ray, out hit))
        {
            // Se acertar alguma coisa, mira nesse ponto
            direcao = (hit.point - ondevaisairabola.position).normalized;
        }
        else
        {
            // Se n�o acertar nada, atira na dire��o da c�mera
            direcao = ray.direction;
        }

        GameObject fireball = Instantiate(esferaVerde, ondevaisairabola.position, Quaternion.LookRotation(direcao));
        Rigidbody rb = fireball.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.linearVelocity = direcao * bolaVelocidade;
        }

        Destroy(fireball, tempoDeVida);

        ParticleSystem particleSystem = fireball.GetComponentInChildren<ParticleSystem>();
        if (particleSystem != null)
        {
            Destroy(particleSystem.gameObject, tempoDeVida);
        }

        Collider fireballCollider = fireball.GetComponent<Collider>();
        if (fireballCollider != null)
        {
            fireballCollider.isTrigger = true;
        }
    }
}
