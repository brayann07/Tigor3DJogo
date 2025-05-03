using UnityEngine;

public class MagoIA : MonoBehaviour
{
    public Transform alvo;  
    public float rangedeatq = 10f;  
    public float cooldown = 2f;  
    public GameObject magiaPreta;  
    private float ultimaVezqataco;

    void Update()
    {
        float distancia = Vector3.Distance(transform.position, alvo.position);

        if (distancia <= rangedeatq && Time.time >= ultimaVezqataco + cooldown)
        {
            AtacarMagia();
            ultimaVezqataco = Time.time;
        }
    }

    void AtacarMagia()
    {
        GameObject magia = Instantiate(magiaPreta, transform.position, Quaternion.identity);

        ProjetilInimigo scriptdeMagia = magia.GetComponent<ProjetilInimigo>();
        scriptdeMagia.direction = (alvo.position - transform.position).normalized;
        Destroy(magia,1f);
    }
}
