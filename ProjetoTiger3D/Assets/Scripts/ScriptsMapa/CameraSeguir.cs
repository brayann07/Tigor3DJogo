using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0f, 3f, -6f);
    public float followSpeed = 10f;
    public float mouseSensitivity = 10f;
    public string tagColisao = "Terrain";

    private float currentYaw = 0f;

    void LateUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X");
        currentYaw += mouseX * mouseSensitivity;

        Quaternion rotation = Quaternion.Euler(0f, currentYaw, 0f);
        Vector3 desiredPosition = target.position + rotation * offset;

        RaycastHit hit;
        if (Physics.Raycast(target.position, desiredPosition - target.position, out hit, offset.magnitude))
        {
            if (hit.collider.CompareTag(tagColisao))
            {
                desiredPosition = hit.point;
            }
        }

        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);
        transform.LookAt(target.position + Vector3.up * 1.5f);
    }
}
