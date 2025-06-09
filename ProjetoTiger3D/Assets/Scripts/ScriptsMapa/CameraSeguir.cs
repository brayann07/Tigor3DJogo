using UnityEngine;

public class CameraSeguir : MonoBehaviour
{
    public Transform target;
    public float distancia = 5f;
    public float altura = 2f;
    public float followSpeed = 5f;

    void LateUpdate()
    {
        if (target == null)
        {
            Debug.Log("Ta nulo esse objeto!");
            return;
        }
        Vector3 behindTarget = target.position - target.forward * distancia + Vector3.up * altura;
        transform.position = Vector3.Lerp(transform.position, behindTarget, followSpeed * Time.deltaTime);
        transform.LookAt(target.position + Vector3.up * 1.5f);
    }
}
