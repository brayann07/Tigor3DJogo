using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float velocidadeRotacao = 10f;
    private float mouseX;

    void Update()
    {
        
        mouseX += Input.GetAxis("Mouse X") * velocidadeRotacao * Time.deltaTime;

        transform.rotation = Quaternion.Euler(0f, mouseX, 0f);
    }
}
