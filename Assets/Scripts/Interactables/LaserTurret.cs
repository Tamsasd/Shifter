using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTurret : EffectedObject
{
    private Transform head;
    private Transform firePoint;
    private Laser laser;

    public override void OnActivate(Interactable effector)
    {
        laser.Enable();
    }

    public override void OnDeactivate(Interactable effector)
    {
        laser.Disable();
    }

    public override void OnValueChange(Interactable effector, float value)
    {
        head.rotation = Quaternion.Euler(head.rotation.x, value, head.rotation.z);
    }

    public override void WhileActive(Interactable effector)
    {
        laser.ShootLaser();
    }

  
    void Start()
    {
        head = transform.Find("Head");
        firePoint = head.Find("FirePoint");
        laser = firePoint.GetComponent<Laser>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
