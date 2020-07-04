using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveWheel : MonoBehaviour
{
    public GameObject[] wheelRightSide;
    public GameObject[] wheelLeftSide;

    private const int speedCoef = 15; //умжножение на speedCoef так как размер поля и танка маленькие получились
    private const int speedRotation = 5; //умжножение на speedRotation так как нужно увеличить скорость поворота относительно направления поворота

    public void movement(float speedMoving)
    {
        //умжножение на 15 так как размер поля и танка маленькие получились
        foreach (GameObject wheel in wheelLeftSide)
        {
            wheel.transform.Rotate(0, transform.rotation.x - speedMoving * speedCoef, 0);
        };

        foreach (GameObject wheel in wheelRightSide)
        {
            wheel.transform.Rotate(0, transform.rotation.x - speedMoving* speedCoef, 0);
        };
    }

    public void rotating(float directionRotation)
    {
        Debug.Log(directionRotation);

        if (directionRotation > 0)
        {
            //умжножение на 5 так как размер поля и танка маленькие получились
            foreach (GameObject wheel in wheelLeftSide)
            {
                wheel.transform.Rotate(0, transform.rotation.x - directionRotation * speedRotation, 0);
            };
        }
        else
        {
            foreach (GameObject wheel in wheelRightSide)
            {
                wheel.transform.Rotate(0, transform.rotation.x + directionRotation * speedRotation, 0);
            };
        }
    }

}
