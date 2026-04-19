using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : EffectedObject
{
    [SerializeField] private Animator animator;

    public override void OnActivate(Interactable effector)
    {
        animator.SetTrigger("Open");
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

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
