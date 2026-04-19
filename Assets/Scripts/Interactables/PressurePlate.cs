using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : Interactable
{
    [SerializeField] private float minimumMass = 1.0f;
    private Animator animator;
    private float massOnButton = 0;
    private bool isActivated = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (massOnButton >= minimumMass)
        {
            WhileActive();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        massOnButton += GetMass(other);
        Debug.Log("mass: " + massOnButton); 
        if (!isActivated && massOnButton >= minimumMass)
        { 
            OnActivate();
            animator.SetBool("buttonPressed", true);
            isActivated = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        massOnButton -= GetMass(other);
        if (isActivated && massOnButton < minimumMass)
        {
            OnDeactivate();
            animator.SetBool("buttonPressed", false);
            isActivated = false;
        }
    }

    private float GetMass(Collider other)
    {
        Rigidbody otherRigidbody = other.attachedRigidbody;        
        
        return otherRigidbody == null ? 0 : otherRigidbody.mass;
    }


}
