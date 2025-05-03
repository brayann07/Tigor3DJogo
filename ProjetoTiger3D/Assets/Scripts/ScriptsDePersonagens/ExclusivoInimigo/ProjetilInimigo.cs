using System.Collections;
using UnityEngine;

public class ProjetilInimigo : MonoBehaviour
{
    public float speed = 10f;
    public Vector3 direction;

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider  other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerHealth vidaPlayer = other.gameObject.GetComponent<PlayerHealth>();
            if (vidaPlayer != null)
            {
                vidaPlayer.TomeDano(1);
            }
            Destroy(gameObject);
        }
    }
}
