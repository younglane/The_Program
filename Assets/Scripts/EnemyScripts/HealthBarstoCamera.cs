using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarstoCamera : MonoBehaviour
{
    public Camera fps_Cam;
    void Update()
    {
        transform.LookAt(transform.position + fps_Cam.transform.rotation * Vector3.back, fps_Cam.transform.rotation * Vector3.up); ;
    }
}
