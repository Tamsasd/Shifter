using UnityEngine;

public class ButtonCollider : MonoBehaviour
{
    private PressurePlate pressurePlate;

    void Awake()
    {
        pressurePlate = GetComponentInParent<PressurePlate>();
    }

    private void OnTriggerEnter(Collider other)
    {
        pressurePlate.OnButtonTriggerEnter(other);
    }

    private void OnTriggerExit(Collider other)
    {
        pressurePlate.OnButtonTriggerExit(other);
    }
}