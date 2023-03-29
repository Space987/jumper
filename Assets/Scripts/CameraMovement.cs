using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    void LateUpdate()
    {
        // Input.GetAxis("Mouse Y");
        // Input.GetAxis("Mouse X");
        transform.position = target.position + offset;    
    }
}
