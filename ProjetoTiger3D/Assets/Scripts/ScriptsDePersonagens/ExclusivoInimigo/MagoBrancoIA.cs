using Unity.VisualScripting;
using UnityEngine;
using System.Collections;
public class MagoBrancoIA : MonoBehaviour
{
    public GameObject alvo;
    public Transform alvoOlhar;
    public float speed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float distancia = Vector3.Distance(gameObject.transform.position, alvo.transform.position);
        if (distancia < 10)
        {
            gameObject.transform.position = Vector3.MoveTowards(transform.position, alvoOlhar.position, speed * Time.deltaTime);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        VidaPlayer vidaPlayer = other.GetComponent<VidaPlayer>();
        if (other.CompareTag("Player"))
        {
            vidaPlayer.TomeDano(1);
            StartCoroutine(CooldowndeAtq());
        }
    }
    public IEnumerator CooldowndeAtq()
    {
        speed = 0f;
        yield return new WaitForSeconds(2);
        speed = 5f;
    }
}
