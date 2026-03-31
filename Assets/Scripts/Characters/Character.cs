using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public abstract Vector3 GetCameraOffset();
    public abstract void ToggleControl(bool value);

    [SerializeField] public Vector3 cameraOffset;
    public bool inControl = false;

    public float moveX;
    public float moveZ;

}
