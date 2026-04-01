using System.Collections.Generic;
using UnityEngine;

public class FaceInMoveDirection : MonoBehaviour
{
    [SerializeField] private DefaultMove dm;

    public float pivotSpeed = 10f;

    void Start()
    {
        if (dm == null)
        {
            dm = GetComponent<DefaultMove>();
        }
    }

    void Update()
    {
        Turn();
    }

    void Turn()
    {
        Vector3 moveDir = dm.GetMoveDirection();

        if (moveDir.sqrMagnitude > 0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDir);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * pivotSpeed);
        }
    }
}