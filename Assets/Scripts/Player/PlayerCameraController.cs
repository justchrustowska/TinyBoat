using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    public float mouseSensitivity = 2f;
    public Transform cameraRoot; // np. pusty obiekt trzymający kamerę
    float xRotation = 0f;
    float yRotation = 0f;

    void Update()
    {
        if (Input.GetMouseButton(1)) // PPM trzymany
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

            yRotation += mouseX;
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -80f, 80f); // ograniczenie góra/dół

            cameraRoot.localRotation = Quaternion.Euler(xRotation, yRotation, 0);
        }
    }
}
