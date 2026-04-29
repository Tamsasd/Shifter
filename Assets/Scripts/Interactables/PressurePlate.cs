using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : Interactable
{
    [SerializeField] private float minimumMass = 1.0f;
    private Animator animator;
    private bool isActivated = false;
    private Dictionary<Rigidbody, int> colliderCounts = new Dictionary<Rigidbody, int>();

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (isActivated) WhileActive();
    }

    public void OnButtonTriggerEnter(Collider other)
    {
        if (other.transform.IsChildOf(transform)) return;

        Rigidbody rb = other.attachedRigidbody;
        if (rb == null) rb = other.GetComponentInParent<Rigidbody>();
        if (rb == null) return;

        if (colliderCounts.ContainsKey(rb))
            colliderCounts[rb]++;
        else
            colliderCounts[rb] = 1;

        CheckState();
    }

    public void OnButtonTriggerExit(Collider other)
    {
        if (other.transform.IsChildOf(transform)) return;

        Rigidbody rb = other.attachedRigidbody;
        if (rb == null) rb = other.GetComponentInParent<Rigidbody>();
        if (rb == null) return;

        if (!colliderCounts.ContainsKey(rb)) return;
        colliderCounts[rb]--;
        if (colliderCounts[rb] <= 0)
            colliderCounts.Remove(rb);

        CheckState();
    }

    private float GetTotalMass()
    {
        float total = 0;
        foreach (Rigidbody rb in colliderCounts.Keys)
            total += rb.mass;
        return total;
    }

    private void CheckState()
    {
        float totalMass = GetTotalMass();

        if (!isActivated && totalMass >= minimumMass)
        {
            isActivated = true;
            animator.SetBool("buttonPressed", true);
            OnActivate();
        }
        else if (isActivated && totalMass < minimumMass)
        {
            isActivated = false;
            animator.SetBool("buttonPressed", false);
            OnDeactivate();
        }
    }
}