using Unity.VisualScripting;
using UnityEngine;

public class Projetil : MonoBehaviour
{
    public float speed = 10f;
    void Start()
    {
        
    }
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Inimigo"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
