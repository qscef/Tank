using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorPlayer : MonoBehaviour
{
    public MoveWheels MoveWheels;

    public void movingAnimation(float speedMoving, float directionRotation)
    {
        if (speedMoving != 0)
        {
            MoveWheels.movement(speedMoving);
        }
        else if (directionRotation != 0)
        {
            MoveWheels.rotating(directionRotation);
        }
    }
}
