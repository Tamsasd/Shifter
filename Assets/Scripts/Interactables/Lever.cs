using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HingeJoint))]
public class Lever : Interactable
{
    [SerializeField] private bool defaultState;
    private bool isActive;

    private HingeJoint hinge;
    private float startAngle;

    private void OnValidate()
    {
        startAngle = defaultState ? -30f : 30f;
        isActive = defaultState;

        transform.localRotation = Quaternion.Euler(0, 0, startAngle);
    }

    private void Awake()
    {
        hinge = GetComponent<HingeJoint>();

        startAngle = defaultState ? -30f : 30f;
        isActive = defaultState;

        hinge.useLimits = true;

        JointLimits limits = hinge.limits;

        limits.min = -30f - startAngle - 1f;
        limits.max = 30f - startAngle + 1f;

        hinge.limits = limits;
    }

    private void Start()
    {
        if (isActive)
        {
            OnActivate();
        }
    }

    void Update()
    {
        float worldAngle = hinge.angle + startAngle;

        if (isActive)
        {
            if (worldAngle > 28f)
            {
                isActive = false;
                OnDeactivate();
                return;
            }

            WhileActive();
        }
        else
        {
            if (worldAngle < -28f)
            {
                isActive = true;
                OnActivate();
            }
        }
    }
}