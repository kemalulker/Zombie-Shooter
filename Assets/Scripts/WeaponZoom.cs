using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;
    [SerializeField] float zoomedOutFOV = 60f;
    [SerializeField] float zoomedInFOV = 25f;
    [SerializeField] float zoomedOutSensivitiy = 2f;
    [SerializeField] float zoomedInSensivitiy = 0.8f;

    RigidbodyFirstPersonController rbFpsController;
    bool zoomToggle = false;

    void Start() {
        rbFpsController = GetComponent<RigidbodyFirstPersonController>();    
    }

    void Update()
    {
        ProcessZoom();
    }

    void ProcessZoom()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (!zoomToggle)
            {
                zoomToggle = true;
                fpsCamera.fieldOfView = zoomedInFOV;
                rbFpsController.mouseLook.XSensitivity = zoomedInSensivitiy;
                rbFpsController.mouseLook.YSensitivity = zoomedInSensivitiy;
            }
            else
            {
                zoomToggle = false;
                fpsCamera.fieldOfView = zoomedOutFOV;
                rbFpsController.mouseLook.XSensitivity = zoomedOutSensivitiy;
                rbFpsController.mouseLook.YSensitivity = zoomedOutSensivitiy;
            }
        }
    }
}
