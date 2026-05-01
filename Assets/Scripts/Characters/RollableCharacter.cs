using Unity.Mathematics;
using UnityEngine;

public class RollableCharacter : Character
{
    [SerializeField] private Transform rollableTransform;
    [SerializeField] private Renderer rollableRenderer;
    [SerializeField] private float radius;
    private Vector3 lastPosition;
    public enum RollAxis
    {
        X, Y, Z
    }

    [SerializeField] private RollAxis axis;
    private Vector3 rotationUnitVector;

    private void Start()
    {
        lastPosition = transform.position;

        Vector3 size = rollableRenderer.bounds.size;

        switch (axis)
        {
            case RollAxis.X:
                rotationUnitVector = new Vector3(1, 0, 0);
                if (radius == 0)
                {
                    radius = (size.y + size.z) / 4;
                }
                break;
            case RollAxis.Y:
                rotationUnitVector = new Vector3(0, 1, 0);
                if (radius == 0)
                {
                    radius = (size.x + size.z) / 4;
                }
                break;
            case RollAxis.Z:
                rotationUnitVector = new Vector3(0, 0, 1);
                if (radius == 0)
                {
                    radius = (size.x + size.y) / 4;
                }
                break;
        }
    }

    private void FixedUpdate()
    {
        rollableTransform.Rotate(rotationUnitVector, getRotationAngle(), Space.Self);
        lastPosition = transform.position;
    }

    private float getRotationAngle()
    {
        float s = Vector3.Distance(lastPosition, transform.position);
        float deg = (180 * s) / (radius * math.PI);
        return deg;
    }
}
