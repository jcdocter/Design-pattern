using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawProjection : MonoBehaviour
{
    public int numPoints = 50;
    public float timeBetweenPoints = 0.1f;

    public LayerMask collidebleLayer;

    private Shoot shootPoint;
   // private PlayerAttack playerAttack;
    private LineRenderer lineRenderer;

    void Start()
    {
        // playerAttack = GetComponent<PlayerAttack>();
        shootPoint = GetComponent<Shoot>();
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        lineRenderer.positionCount = numPoints;
        List<Vector3> points = new List<Vector3>();
        Vector3 startPosition = shootPoint.firePosition.position;
        Vector3 startVelocity = shootPoint.firePosition.up;

        for(float i = 0; i < numPoints; i+= timeBetweenPoints)
        {
            Vector3 newPoint = startPosition + i * startVelocity;
            newPoint.y = startPosition.y + startVelocity.y * i + Physics.gravity.y / 2f * i * i;
            points.Add(newPoint);

            if(Physics.OverlapSphere(newPoint, 2, collidebleLayer).Length > 0)
            {
                lineRenderer.positionCount = points.Count;
                break;
            }
        }

        lineRenderer.SetPositions(points.ToArray());
    }
}
