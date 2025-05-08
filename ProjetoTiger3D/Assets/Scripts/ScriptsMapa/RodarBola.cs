using Unity.VisualScripting;
using UnityEngine;

public class RodarBola : MonoBehaviour
{
    public GameObject esfera;
    public float velocidadeRotacao = 20f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (esfera!=null)
        {
            transform.Rotate(Vector3.up * velocidadeRotacao * Time.deltaTime);
        }
    }
}