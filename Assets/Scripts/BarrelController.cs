using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelController : MonoBehaviour
{
    public GameObject Barrel;
    public GameObject BarrelPointShot;
    public Transform BarrelPointShotForward;
    public GameObject Bullet;

    private Vector2 offsetAngle;
    private const float timeLifeBullet = 5f;
    private const int forceBullet = 50;
    private const int turningForce = 10;

    public void rotateHorizontalBarrel(float rotateHorizontal)
    {
        offsetAngle.x = rotateHorizontal;
        rotateBarrel();
    }
        
    public void rotateVerticalBarrel(float rotateVertical)
    {
        offsetAngle.y = rotateVertical;
        rotateBarrel();
    }

    private void rotateBarrel()
    {
        Barrel.transform.localRotation = Quaternion.identity; 
        Barrel.transform.Rotate(offsetAngle.y * turningForce, offsetAngle.x * turningForce, 0);
    }

    public void shot()
    {
        var bullet = Instantiate(Bullet);
        bullet.transform.position = BarrelPointShot.transform.position;
        var rbBullet = bullet.GetComponent<Rigidbody>();
        bullet.transform.LookAt(BarrelPointShotForward);
        rbBullet.AddForce(bullet.transform.forward * forceBullet, ForceMode.VelocityChange);

        Destroy(bullet, timeLifeBullet);
    }
}