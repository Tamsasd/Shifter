using UnityEngine;

public class Ball : MonoBehaviour
{
    public Transform rootTransform;
    private Vector3 lastPosition;
    private float radius;

    void Start()
    {
        SphereCollider sphere = rootTransform.GetComponent<SphereCollider>();

        if (sphere != null)
        {
            radius = sphere.radius * rootTransform.lossyScale.x;
        }
        else
        {
            radius = GetComponent<Renderer>().bounds.extents.y;
        }

        lastPosition = rootTransform.position;
    }

    void Update()
    {
        Vector3 distanceMoved = rootTransform.position - lastPosition;
        float distance = distanceMoved.magnitude;

        if (distance > 0.001f)
        {
            Vector3 rotationAxis = Vector3.Cross(Vector3.up, distanceMoved).normalized;

            float rotationAngle = (distance / (2 * Mathf.PI * radius)) * 360f;

            transform.Rotate(rotationAxis, rotationAngle, Space.World);
        }

        lastPosition = rootTransform.position;
    }
}