using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : Interactable
{
    [SerializeField] private float minimumMass = 1.0f;
    [SerializeField] private float activationDelay = 2.0f; // Time in seconds before it activates

    private Animator animator;
    private float massOnButton = 0;
    private bool isActivated = false;
    private float timeOnButton = 0f; // Tracks how long the mass has been sufficient

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if there is enough mass on the plate
        if (massOnButton >= minimumMass)
        {
            if (!isActivated)
            {
                // Add the time passed since the last frame
                timeOnButton += Time.deltaTime;

                // Check if the delay has been reached
                if (timeOnButton >= activationDelay)
                {
                    ActivatePlate();
                }
            }
            else
            {
                // The plate is fully activated and the delay is over
                WhileActive();
            }
        }
        else
        {
            // Reset the timer if the mass drops below the threshold
            timeOnButton = 0f;

            // Deactivate the plate if it was previously active
            if (isActivated)
            {
                DeactivatePlate();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        massOnButton += GetMass(other);
        Debug.Log("mass: " + massOnButton);
    }

    private void OnTriggerExit(Collider other)
    {
        massOnButton -= GetMass(other);
    }

    private float GetMass(Collider other)
    {
        Rigidbody otherRigidbody = other.attachedRigidbody;

        return otherRigidbody == null ? 0 : otherRigidbody.mass;
    }

    private void ActivatePlate()
    {
        OnActivate();
        animator.SetBool("buttonPressed", true);
        isActivated = true;
    }

    private void DeactivatePlate()
    {
        OnDeactivate();
        animator.SetBool("buttonPressed", false);
        isActivated = false;
    }
}