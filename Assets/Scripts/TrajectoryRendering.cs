using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryRendering : MonoBehaviour
{
    private LineRenderer shootingLine;
    
    // Start is called before the first frame update
    void Start()
    {
        shootingLine = GetComponent<LineRenderer>();
    }

    public void showShootingLine(Vector3 startPoint, Vector3 speed)
    {
        Vector3[] pointToShootingLine = new Vector3[100];
        shootingLine.positionCount = pointToShootingLine.Length;

        for (int i = 0; i < pointToShootingLine.Length; i++)
        {
            float time = i * 0.1f;

            pointToShootingLine[i] = startPoint + speed * time + Physics.gravity * time * time / 2f; 
        }

        shootingLine.SetPositions(pointToShootingLine);
    }
}
