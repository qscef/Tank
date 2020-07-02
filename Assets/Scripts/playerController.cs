using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private Vector2 direction;
    private float speedMoving;

    public float accelerationSpeed;
    public float maxSpeed;
    public float friction;
    public float speedRotation;

    // Start is called before the first frame update
    void Start()
    {
        speedMoving = 0;
    }

    void FixedUpdate()
    {
        // gas control
        if (Input.GetKey(KeyCode.W)) {
            direction.x = 1;
        }
        else if (Input.GetKey(KeyCode.S)) {
            direction.x = -1;
        }
        else {
            direction.x = 0;
        }

        if (direction.x != 0)
        {
            // speed limiter
            if ((speedMoving > -maxSpeed) && (speedMoving < maxSpeed)) {
                speedMoving = speedMoving + (direction.x * accelerationSpeed);
            }
        }
        // friction force
        else if (speedMoving > 0) {
            if (speedMoving - friction < friction) {
                speedMoving = 0;
            }
            else {
                speedMoving = speedMoving - friction;
            }
        }
        else if (speedMoving < 0) {
            if (speedMoving + friction > friction) {
                speedMoving = 0;
            }
            else {
                speedMoving = speedMoving + friction;
            }
        }
        Debug.Log(speedMoving);
        transform.Translate(0, 0, speedMoving);

        // rotation
        if (Input.GetKey(KeyCode.A)) {
            direction.y = -1;
        }
        else if (Input.GetKey(KeyCode.D)) {
            direction.y = 1;
        }
        else {
            direction.y = 0;
        }
        // for reverse control
        if (speedMoving < 0) {
            transform.Rotate(0, speedRotation * -direction.y, 0);
        }
        else {
            transform.Rotate(0, speedRotation * direction.y, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
