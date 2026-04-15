using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Laser : MonoBehaviour
{
    [SerializeField] private float maxLaserDistance = 100.0f;
    [SerializeField] private int maxBounces = 5;
    [SerializeField] private LayerMask hitLayers;
    private LineRenderer lineRenderer;

    private void OnValidate()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
    }

    public void Enable() => lineRenderer.enabled = true;
    public void Disable() => lineRenderer.enabled = false;

    public void ShootLaser()
    {
        List<Vector3> points = new List<Vector3>();
        points.Add(transform.position);

        Vector3 rayOrigin = transform.position;
        Vector3 rayDirection = transform.forward;

        for (int i = 0; i < maxBounces; i++)
        {
            RaycastHit hit;
            if (Physics.Raycast(rayOrigin, rayDirection, out hit, maxLaserDistance, hitLayers))
            {
                points.Add(hit.point);

                LaserActivated sensor = hit.collider.GetComponent<LaserActivated>();
                if (sensor != null)
                {
                    sensor.ReceiveLaserHit();
                }
                if (hit.collider.CompareTag("Mirror"))
                {
                    rayOrigin = hit.point + hit.normal * 0.001f;
                    rayDirection = Vector3.Reflect(rayDirection, hit.normal);
                }
                if (hit.collider.CompareTag("Character"))
                {
                    if (hit.transform.TryGetComponent<ChickenCharacter>(out ChickenCharacter cc))
                    {
                        cc.Die();
                    }
                }
                else
                {
                    break;
                }
            }
            else
            {
                points.Add(rayOrigin + (rayDirection * maxLaserDistance));
                break;
            }
        }

        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPositions(points.ToArray());
    }
}