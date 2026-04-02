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

    public AudioSource audioSource;
    public AudioClip audioClip;
    public virtual void playSoundOnMove(params KeyCode[] keycodes)
    {
        if (inControl && audioSource != null)
        {
            bool isPressingKey = false;
            foreach (KeyCode k in keycodes)
            {
                if (Input.GetKey(k))
                {
                    isPressingKey = true;
                    break;
                }
            }

            if (isPressingKey)
            {
                audioSource.loop = true;

                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
            }
            else
            {
                audioSource.loop = false;
                audioSource.Stop();
            }
        }
    }

    [SerializeField] protected Transform cameraPivot;
    protected bool inControl = false;

    protected float moveX;
    protected float moveZ;
}
