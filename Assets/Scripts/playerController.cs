using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2 direction;
    private float speedMoving;

    public float accelerationSpeed;
    public float maxSpeed;
    public float friction;
    public float speedRotation;

    public AnimatorPlayer AnimatorPlayer;
    public GUIController GUI;
    public BarrelController BarrelController;

    void Start()
    {
        speedMoving = 0;
        GUI.horizontalAngle += changeBarrelAngleHorizontal;
        GUI.verticalAngle += changeBarrelAngleVertical;
        GUI.shot += shotBarrel;
    }

    // можно было использовать Input.GetAxis("Vertical"), но решил попробовать отслеживать прото нажатия
    void FixedUpdate() 
    {
        // gas control
        if (Input.GetKey(KeyCode.W))
        {
            direction.x = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            direction.x = -1;
        }
        else
        {
            direction.x = 0;
        }

        if (direction.x != 0)
        {
            // speed limiter
            if (Mathf.Abs(speedMoving) < maxSpeed)
            {
                speedMoving += (direction.x * accelerationSpeed);
            }
        }
        // friction force
        else if (speedMoving > 0)
        {
            if (speedMoving - friction < friction)
            {
                speedMoving = 0;
            }
            else
            {
                speedMoving -= friction;
            }
        }
        else if (speedMoving < 0)
        {
            if (speedMoving + friction > friction)
            {
                speedMoving = 0;
            }
            else
            {
                speedMoving += friction;
            }
        }
        transform.Translate(0, 0, speedMoving);

        // rotation
        if (Input.GetKey(KeyCode.A))
        {
            direction.y = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            direction.y = 1;
        }
        else
        {
            direction.y = 0;
        }
        // for reverse control
        if (speedMoving < 0)
        {
            transform.Rotate(0, speedRotation * -direction.y, 0);
        }
        else
        {
            transform.Rotate(0, speedRotation * direction.y, 0);
        }

        //animation
        AnimatorPlayer.movingAnimation(speedMoving, direction.y);

    }

    void changeBarrelAngleHorizontal(float horizontalAngle)
    {
        BarrelController.rotateHorizontalBarrel(horizontalAngle);
    }

    void changeBarrelAngleVertical(float verticalAngle)
    {
        BarrelController.rotateVerticalBarrel(verticalAngle);
    }

    void shotBarrel()
    {
        if (speedMoving == 0)
        {
            BarrelController.shot();
        }
    }
}
