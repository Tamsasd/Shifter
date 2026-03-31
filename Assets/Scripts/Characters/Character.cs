using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public abstract Vector3 GetCameraOffset();
    public abstract void ToggleControl(bool value);
    public abstract bool HasControl();

    [SerializeField] protected Vector3 cameraOffset;
    protected bool inControl = false;

    protected float moveX;
    protected float moveZ;

}
