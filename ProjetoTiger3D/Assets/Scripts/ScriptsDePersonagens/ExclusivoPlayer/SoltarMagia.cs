using UnityEngine;

public class SoltarMagia : MonoBehaviour
{
    public GameObject projetilPreto;
    public GameObject projetilVerde;
    public Transform Atirar;

    public float cooldown = 1f;
    private float proximoDisparo = 0f;
    public Animator anim;
    void Start()
    {
        anim = GetComponentInParent<Animator>();

    }
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
        Instantiate(projetilPreto, Atirar.position, Atirar.rotation);
    }

    void AtirarVerde()
    {
        Instantiate(projetilVerde, Atirar.position, Atirar.rotation);
    }
}
