using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : EffectedObject
{
    private Animator animator;

    public override void OnActivate(Interactable effector)
    {
        if (animator != null)
        {
            animator.SetTrigger("Open");
        }
    }

    public override void OnDeactivate(Interactable effector)
    {
        animator.SetTrigger("Close");
    }

    public override void OnValueChange(Interactable effector, float value)
    {
        return;
    }

    public override void WhileActive(Interactable effector)
    {
        return;
    }

    void Awake()
    {
        animator = GetComponent<Animator>();

        if (animator == null)
        {
            Debug.LogError($"Animator missing on {gameObject.name}!", this);
        }
    }
}
