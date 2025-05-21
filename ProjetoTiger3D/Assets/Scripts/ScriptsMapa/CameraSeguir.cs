using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float distance = 6f;
    public float height = 3f;
    public float mouseSensitivity = 5f;
    public float followSpeed = 10f;
    public float minY = -20f;
    public float maxY = 60f;

    private float rotationY = 0f;
    private float rotationX = 20f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void LateUpdate()
    {
        
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        rotationY += mouseX;
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, minY, maxY);

        Quaternion rotation = Quaternion.Euler(rotationX, rotationY, 0f);
        Vector3 desiredCameraPos = target.position + rotation * new Vector3(0f, height, -distance);
        Vector3 direction = desiredCameraPos - target.position;
        Ray ray = new Ray(target.position + Vector3.up * 1.5f, direction.normalized);
        float currentDistance = direction.magnitude;

        if (Physics.Raycast(ray, out RaycastHit hit, currentDistance))
        {
            if (hit.collider.CompareTag("Terrain"))
            {
               
                desiredCameraPos = hit.point - direction.normalized * 0.2f; 
            }
        }
        transform.position = Vector3.Lerp(transform.position, desiredCameraPos, followSpeed * Time.deltaTime);
        transform.LookAt(target.position + Vector3.up * 1.5f);
    }
}
