using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EffectedCube : EffectedObject
{
    [SerializeField] private Material activeMaterial;
    private Material inactiveMaterial;
    private MeshRenderer renderer;

    public override void OnActivate(Interactable effector)
    {

        if (effector.name == "Lever")
        {
            renderer.material = activeMaterial;
        }
    }

    public override void OnDeactivate(Interactable effector)
    {

        if (effector.name == "Lever")
        {
            renderer.material = inactiveMaterial;
        }
    }

    public override void OnValueChange(Interactable effector, float value)
    {
        transform.position = new Vector3(transform.position.x, 0.5f + (value / 180.0f * 2), transform.position.z);
    }

    public override void WhileActive(Interactable effector)
    {
        if (effector.name == "Button")
        {
            transform.Rotate(0, 1, 0);
        }
    }

    private void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        inactiveMaterial = renderer.material;
    }
}
