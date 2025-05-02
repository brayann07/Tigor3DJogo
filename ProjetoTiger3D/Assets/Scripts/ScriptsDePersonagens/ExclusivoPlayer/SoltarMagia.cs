using JetBrains.Annotations;
using UnityEngine;

public class SoltarMagia : MonoBehaviour
{
    public GameObject projetilPreto;
    public GameObject projetilVerde;
    public Transform Atirar;

    public float cooldown = 1f;
    private float proximoDisparo = 0f;
    public Animator anim;
    private float bolavelocidade = 10f;
    private float tempoDeVida = 2f;
    void Start()
    {
        anim = GetComponentInParent<Animator>();

    }

    [System.Obsolete]
    void Update()
    {
        if (Time.time >= proximoDisparo)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                anim.SetInteger("transitions", 4);
                AtirarPreto();
                proximoDisparo = Time.time + cooldown;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            { 
                anim.SetInteger("transitions", 4);
                AtirarVerde();
                proximoDisparo = Time.time + cooldown;
            }
        }
    }
    void AtirarPreto()
    {
        if(projetilPreto != null){
            
            GameObject balaPreta = Instantiate(projetilPreto, Atirar.position, Atirar.rotation);
            Debug.Log("Atirou Magia Psiquica");
            Rigidbody rb = balaPreta.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false;  
                rb.linearVelocity = Atirar.forward * bolavelocidade;
            }
            Destroy(balaPreta, tempoDeVida);
            ParticleSystem particleSystem = balaPreta.GetComponentInChildren<ParticleSystem>();
            if (particleSystem != null)
            {
                Destroy(particleSystem.gameObject, tempoDeVida);
            }
            Collider colisordabola = balaPreta.GetComponent<Collider>();
            if (colisordabola != null)
            {
                colisordabola.isTrigger = true;
            }
        }else{
            Debug.Log("nao existe essa bola");
        }    
    }
    void AtirarVerde()
    {
        if(projetilVerde != null){
            GameObject balaVerde = Instantiate(projetilVerde, Atirar.position, Atirar.rotation);
            Rigidbody rb = balaVerde.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false;  
                rb.linearVelocity = Atirar.forward * bolavelocidade;
            }
            Destroy(balaVerde, tempoDeVida);
            ParticleSystem particleSystem = balaVerde.GetComponentInChildren<ParticleSystem>();
            if (particleSystem != null)
            {
                Destroy(particleSystem.gameObject, tempoDeVida);
            }
            Collider colisordabola = balaVerde.GetComponent<Collider>();
            if (colisordabola != null)
            {
                colisordabola.isTrigger = true;
            }
        }else{
            Debug.Log("nao existe essa bola");
        }
        
    }
}
