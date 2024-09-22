using UnityEngine;

public class CameraView : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 100f;
    private float rotateX = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        rotateX -= mouseY;
        rotateX = Mathf.Clamp(rotateX, -60f, 60f);

        transform.localRotation = Quaternion.Euler(rotateX, 0f, 0f);
    }
}
