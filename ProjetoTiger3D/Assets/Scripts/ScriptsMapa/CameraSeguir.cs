using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0f, 3f, -6f);
    public float followSpeed = 10f;
    public float mouseSensitivity = 5f;
    private float naoseiX = 0f;

    void LateUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X");

        naoseiX += mouseX * mouseSensitivity;

        Quaternion rotation = Quaternion.Euler(0f, naoseiX, 0f);
        Vector3 desiredPosition = target.position + rotation * offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);
        transform.LookAt(target);
    }
}
