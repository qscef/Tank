using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelController : MonoBehaviour
{
    public GameObject Barrel;
    public GameObject BarrelPointShot;
    public Transform BarrelPointShotForward;
    public GameObject Bullet;
    public GameObject GhostBullet;
    public TrajectoryRendering Trajectory;

    private Vector2 offsetAngle;
    private float timeLifeBullet;
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

        showTrajectory();
    }

    private void trajectoryCalculation(bool isShot)
    {
        var bullet = (isShot) ? Instantiate(Bullet): Instantiate(GhostBullet);
        bullet.transform.position = BarrelPointShot.transform.position;
        var rbBullet = bullet.GetComponent<Rigidbody>();
        bullet.transform.LookAt(BarrelPointShotForward);
        rbBullet.AddForce(bullet.transform.forward * forceBullet, ForceMode.VelocityChange);

        if (isShot)
        {
            timeLifeBullet = 5f;
        }
        else
        {
            timeLifeBullet = 0;
            Trajectory.showShootingLine(bullet.transform.position, bullet.transform.forward * forceBullet);
        }

        Destroy(bullet, timeLifeBullet);
    }

    public void shot()
    {
        bool isShot = true;
        trajectoryCalculation(isShot);
    }

    public void hideLineTreajectoryShot()
    {
        Trajectory.showShootingLine(Vector3.zero, Vector3.zero);
    }

    public void showTrajectory()
    {
        bool isShot = false;
        trajectoryCalculation(isShot);
    }
}