using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animatorPlayer : MonoBehaviour
{
    public moveWheel moveWheel;

    public void movingAnimation(float speedMoving, float directionRotation)
    {
        if (speedMoving != 0)
        {
            moveWheel.movement(speedMoving);
        }
        else if (directionRotation != 0)
        {
            moveWheel.rotating(directionRotation);
        }
    }
}
