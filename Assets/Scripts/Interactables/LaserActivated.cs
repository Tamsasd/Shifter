using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class LaserActivated : Interactable
{
    [SerializeField] private Material activeMaterial;
    private Material inactiveMaterial;
    private MeshRenderer meshRenderer;

    private bool isCurrentlyHit = false;
    private float hitTimeout = 0.1f;
    private float lastHitTime;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Laser"))
        {
            OnActivate();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Laser"))
        {
            OnDeactivate();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Laser"))
        {
            WhileActive();
        }
    }

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        inactiveMaterial = meshRenderer.material;
    }

    public void ReceiveLaserHit()
    {
        if (!isCurrentlyHit)
        {
            isCurrentlyHit = true;
            meshRenderer.material = activeMaterial;
            OnActivate();
        }

        lastHitTime = Time.time;
        WhileActive();
    }

    private void Update()
    {
        if (isCurrentlyHit && Time.time - lastHitTime > hitTimeout)
        {
            isCurrentlyHit = false;
            meshRenderer.material = inactiveMaterial;
            OnDeactivate();
        }
    }
}
