using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float distance = 6f;
    public float height = 3f;
    public float followSpeed = 10f;

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 behindTarget = target.position - target.forward * distance + Vector3.up * height;
        transform.position = Vector3.Lerp(transform.position, behindTarget, followSpeed * Time.deltaTime);
        transform.LookAt(target.position + Vector3.up * 1.5f);
    }
}
