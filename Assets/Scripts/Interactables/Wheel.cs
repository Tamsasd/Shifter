using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HingeJoint))]
public class Wheel : Interactable
{
    private float lastAngle;
    private HingeJoint hinge;

    // Start is called before the first frame update
    void Start()
    {
        hinge = GetComponent<HingeJoint>();
        lastAngle = hinge.angle;
    }

    // Update is called once per frame
    void Update()
    {
        float currentAngle = hinge.angle;
        if (lastAngle != currentAngle)
        {
            OnValueChange(currentAngle);
        }
    }
}
