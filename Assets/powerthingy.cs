using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class powerthingy : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float radius = 2;
    private LineRenderer lineRenderer;

    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.startWidth = 0.2f;
        lineRenderer.endWidth = 0.05f;
    }

    void Update()
    {
        float currdist = Vector3.Distance(pointA.position, pointB.position);
        if (currdist>radius)
        {
            Vector3 mov= pointB.position-pointA.position;
            mov = mov.normalized;
            mov *= (currdist - radius);
            pointA.position += mov;
        }
        Vector3 startPos = new Vector3(pointA.position.x, pointA.position.y, 0f);
        Vector3 endPos = new Vector3(pointB.position.x, pointB.position.y, 0f);
        lineRenderer.SetPosition(0, startPos);
        lineRenderer.SetPosition(1, endPos);
    }
}
