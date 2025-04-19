using UnityEngine;

public class MagiaPreta : MonoBehaviour
{
    public GameObject esferaPreta;
    public Transform ondevaisairabola;
    private float bolaVelocidade = 10f;
    private float tempoDeVida = 2f;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            anim.SetInteger("transitions", 3);
            JogarABola();
        }
    }
    void JogarABola()
    {
        GameObject fireball = Instantiate(esferaPreta, ondevaisairabola.position, ondevaisairabola.rotation);
        Rigidbody rb = fireball.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = ondevaisairabola.forward * bolaVelocidade;
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
