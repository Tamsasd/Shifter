using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public Transform GetCameraPivot()
    {
        if (cameraPivot == null)
        {
            cameraPivot = transform;
        }
        return cameraPivot;
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

    [SerializeField] protected Transform cameraPivot;
    protected bool inControl = false;

    protected float moveX;
    protected float moveZ;
}
