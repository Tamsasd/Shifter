using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public Vector3 GetCameraOffset()
    {
        return cameraOffset;
    }
    public virtual void ToggleControl(bool value)
    {
        inControl = value;
        GetComponent<AbstractMove>().ToggleControl(value);
    }
    public bool HasControl()
    {
        return inControl;
    }

    [SerializeField] protected Vector3 cameraOffset;
    protected bool inControl = false;

    protected float moveX;
    protected float moveZ;
}
