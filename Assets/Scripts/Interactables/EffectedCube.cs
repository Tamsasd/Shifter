using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent (typeof (MeshRenderer))]
public class EffectedCube : EffectedObject
{
    [SerializeField] private Material activeMaterial;
    private Material inactiveMaterial;
    private MeshRenderer meshRenderer;

    public override void OnActivate(Interactable effector)
    {

        if (effector.name == "Orb")
        {
            meshRenderer.material = activeMaterial;
        }
    }

    public override void OnDeactivate(Interactable effector)
    {

        if (effector.name == "Orb")
        {
            meshRenderer.material = inactiveMaterial;
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
        meshRenderer = GetComponent<MeshRenderer>();
        inactiveMaterial = meshRenderer.material;
    }
}
