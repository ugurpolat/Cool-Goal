using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class route2 : MonoBehaviour
{
    //[SerializeField]
    //private Transform[] controlPoints;

    private Vector3 gizmosPosition;

//--------------------------------------------
    public LineRenderer lineRenderer;
    public Transform point0, point1, point2;
    
    private int numPoints = 50;

    private Vector3[] positions= new Vector3[50];


    //private void OnDrawGizmos()
    //{
    //    for (float t = 0; t <= 1; t += 0.05f)
    //    {

    //        gizmosPosition = Mathf.Pow(1 - t, 3) * controlPoints[0].position +
    //                         3 * Mathf.Pow(1 - t, 2) * t * controlPoints[1].position +
    //                         3 * (1 - t) * Mathf.Pow(t, 2) * controlPoints[2].position +
    //                         Mathf.Pow(t, 3) * controlPoints[3].position;

    //        //gizmosPosition = controlPoints[0].position * Mathf.Pow(1 - t, 2) + 2 * t * controlPoints[1].position * (1 - t) + controlPoints[2].position * Mathf.Pow(t, 2);

    //        Gizmos.DrawSphere(gizmosPosition, 0.25f);


    //    }

    //    //Gizmos.DrawLine(new Vector3(controlPoints[0].position.x, controlPoints[0].position.y, controlPoints[0].position.z),
    //    //                new Vector3(controlPoints[1].position.x, controlPoints[1].position.y, controlPoints[1].position.z));


    //    //Gizmos.DrawLine(new Vector3(controlPoints[2].position.x, controlPoints[2].position.y, controlPoints[2].position.z),
    //    //                new Vector3(controlPoints[3].position.x, controlPoints[3].position.y, controlPoints[3].position.z));

    //}

    void Start()
    {
        lineRenderer.positionCount = numPoints;
        DrawCurve();

    }

    void Update()
    {
        DrawCurve();
    }

    public Vector3 CalculateQuadraticBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        Vector3 p = uu * p0;
        p += 2 * u * t * p1;
        p += tt * p2;
        return p;
    }

    private void DrawCurve()
    {
        for (int i = 1; i < numPoints + 1; i++)
        {
            float t = i / (float)numPoints;
            positions[i - 1] = CalculateQuadraticBezierPoint(t, point0.position, point1.position, point2.position);
        }
        lineRenderer.SetPositions(positions);
    }
}
