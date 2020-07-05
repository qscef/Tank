using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelController : MonoBehaviour
{
    public GameObject Barrel;

    private float rotateZ;
    private Vector2 offsetAngle;

    void Start()
    {
    }

    public void rotateHorizontalBerral(float rotateHorizontal)
    {
        offsetAngle.x = rotateHorizontal;
        rotateBerral();
    }
        
    public void rotateVerticalBerral(float rotateVertical)
    {
        offsetAngle.y = rotateVertical;
        rotateBerral();
    }

    private void rotateBerral()
    {
        Barrel.transform.localRotation = Quaternion.identity; 
        Barrel.transform.Rotate(offsetAngle.y * 10, offsetAngle.x * 10, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            //shot
        }
    }
}
