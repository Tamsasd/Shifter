using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectedCube : EffectedObject
{
    public override void OnActivate()
    {
        transform.position = new Vector3(transform.position.x, 2, transform.position.z);
        Debug.Log("Activated " + this.name);
    }

    public override void OnDeactivate()
    {
        transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
        Debug.Log("Deactivated " + this.name);
    }

    public override void WhileActive()
    {
        transform.Rotate(0, 1, 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
