using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public Transform cameraPosition;
    public Transform target;

    void Start() {
    }

    void LateUpdate() {
        transform.position = cameraPosition.position;
        transform.LookAt(target);
    }
}
