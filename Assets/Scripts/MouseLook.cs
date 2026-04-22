using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensitivity = 1.5f;
    public float smoothing = 1.5f;

    private float xMousePos;
    private float yMousePos;
    private float smoothedMousePos;
    private float verticalLook;
    private Camera playerCamera;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerCamera = Camera.main;
    }

    void Update()
    {
        GetInput();
        ModifyInput();
        MovePlayer();
    }

    void GetInput()
    {
        xMousePos = Input.GetAxis("Mouse X") * sensitivity;
        yMousePos = Input.GetAxis("Mouse Y") * sensitivity;
    }

    void ModifyInput()
    {
        xMousePos *= sensitivity * smoothing;
        smoothedMousePos = Mathf.Lerp(smoothedMousePos, xMousePos, 1f / smoothing);
    }

    void MovePlayer()
    {
        transform.Rotate(Vector3.up * smoothedMousePos);

        verticalLook -= yMousePos;
        verticalLook = Mathf.Clamp(verticalLook, -80f, 80f);

        if (playerCamera != null)
        {
            playerCamera.transform.localRotation = Quaternion.Euler(verticalLook, 0f, 0f);
        }
    }
}
