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
            // Ensure the local volume is full so the Mixer can do its job
            if (audioSource.volume != 1f) audioSource.volume = 1f;

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
                if (!audioSource.isPlaying) audioSource.Play();
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

    [SerializeField] private int outlineLayerIndex = 1;
    public virtual void EnableOutline()
    {
        List<Renderer> targetRenderers = new List<Renderer>(GetComponentsInChildren<Renderer>());
        foreach (Renderer renderer in targetRenderers)
        {
            renderer.renderingLayerMask |= (1u << outlineLayerIndex);
        }
    }

    public virtual void DisableOutline()
    {
        List<Renderer> targetRenderers = new List<Renderer>(GetComponentsInChildren<Renderer>());
        foreach (Renderer renderer in targetRenderers)
        {
            renderer.renderingLayerMask &= ~(1u << outlineLayerIndex);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ShiftCollider") && !inControl)
        {
            EnableOutline();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ShiftCollider"))
        {
            DisableOutline();
        }
    }


}
