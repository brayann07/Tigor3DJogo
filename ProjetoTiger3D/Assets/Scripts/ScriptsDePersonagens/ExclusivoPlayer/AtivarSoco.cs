using System.Collections;
using UnityEngine;

public class AtivarSoco : MonoBehaviour
{
    public GameObject hitboxsoco;
    private float duracaoSoco = 1f;
    Animator anim;
    private int auxCD = 0; 
    void Start()
    {
        anim = GetComponentInParent<Animator>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3)) // pra evitar spam acho
        {
            auxCD +=1;
            anim.SetInteger("transitions",3);
            StartCoroutine(Ativar());
        }
    }

    IEnumerator Ativar()
    {
        hitboxsoco.SetActive(true);
        yield return new WaitForSeconds(duracaoSoco);
        hitboxsoco.SetActive(false);
    }
}
