using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonLook : MonoBehaviour
{
    public float lookSpeed = 3;
    private Vector2 rotation = Vector2.zero;
    public Rect crosshairRect;
    public float size = 0.05f;

    public bool isPlaying = true;

    // Start is called before the first frame update
    void Start()
    {
        float crosshairSize = Screen.width * size;
        crosshairRect = new Rect(Screen.width / 2 - crosshairSize / 2,
                                  Screen.height / 2 - crosshairSize / 2,
                                  crosshairSize, crosshairSize);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying) Cursor.lockState = CursorLockMode.Locked; // Locks the mouse
        else Cursor.lockState = CursorLockMode.None;
        
        if (isPlaying)
        {
            rotation.y += Input.GetAxis("Mouse X");
            rotation.x += -Input.GetAxis("Mouse Y");

            rotation.x = Mathf.Clamp(rotation.x, -15f, 15f);
            transform.eulerAngles = new Vector2(0, rotation.y) * lookSpeed;
            Camera.main.transform.localRotation = Quaternion.Euler(rotation.x * lookSpeed, 0, 0);
        }
    }
}
