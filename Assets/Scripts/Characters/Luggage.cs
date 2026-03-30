using System.Collections.Generic;
using UnityEngine;

public class Luggage : Character
{
    public List<Transform> wheels = new List<Transform>();
    private DefaultMove dm;

    public float wheelPivotSpeed = 10f;

    [SerializeField] private Vector3 cameraOffset;

    void Start()
    {
        foreach (Transform t in transform)
        {
            if (t.name.ToLower().StartsWith("wheel"))
            {
                wheels.Add(t);
            }           
        }

        dm = GetComponent<DefaultMove>();
    }

    void Update()
    {
        Vector3 moveDir = dm.GetMoveDirection();

        if (moveDir.sqrMagnitude > 0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDir);

            foreach (Transform t in wheels)
            {
                t.rotation = Quaternion.Slerp(t.rotation, targetRotation, Time.deltaTime * wheelPivotSpeed);
            }
        }
    }

    public override Vector3 GetCameraOffset()
    {
        return cameraOffset;
    }
}