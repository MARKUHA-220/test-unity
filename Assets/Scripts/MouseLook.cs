using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensitivity = 1.5f;
    public float smoothing = 1.5f;
    private float xMausePos;
    private float yMausePos;
    private float smothedMousePos;
    private float currentLookingPos;
    private float verticalLook;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        GetInput();
        ModifyInput();
        MovePlayer();
    }
    void GetInput()
    {
        xMausePos = Input.GetAxis("Mouse X") * sensitivity;
        yMausePos = Input.GetAxis("Mouse Y") * sensitivity;
    }
    void ModifyInput()
    {
        xMausePos *= sensitivity * smoothing;
        smothedMousePos = Mathf.Lerp(smothedMousePos, xMausePos, 1f / smoothing);
    }
    void MovePlayer()
    {
        transform.Rotate(Vector3.up * smothedMousePos);
        verticalLook -= yMausePos;
        verticalLook = Mathf.Clamp(verticalLook, -80f, 80f);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalLook, 0f, 0f);
    }

}
