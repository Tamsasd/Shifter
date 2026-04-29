using UnityEngine;

public class Door : EffectedObject
{
    private Animator animator;
    [SerializeField] private bool defaultState = false;

    public override void OnActivate(Interactable effector)
    {
        animator.SetBool("Open", !defaultState);
    }

    public override void OnDeactivate(Interactable effector)
    {
        animator.SetBool("Open", defaultState);
    }

    public override void OnValueChange(Interactable effector, float value) { }
    public override void WhileActive(Interactable effector) { }

    void Awake()
    {
        animator = GetComponent<Animator>();
        if (animator == null) Debug.LogError($"Animator missing on {gameObject.name}!", this);
        animator.SetBool("Open", defaultState);
    }
}