using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform cameraPosition;
    public Transform target;

    void LateUpdate() {
        transform.position = cameraPosition.position;
        transform.LookAt(target);
    }
}
