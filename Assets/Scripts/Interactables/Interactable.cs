using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] List<EffectedObject> effectedObjects = new List<EffectedObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected virtual void OnActivate()
    {
        foreach (EffectedObject o in effectedObjects)
        {
            o.OnActivate(this);
        }
    }

    protected virtual void OnDeactivate()
    {
        foreach (EffectedObject o in effectedObjects)
        {
            o.OnDeactivate(this);
        }
    }

    protected virtual void WhileActive()
    {
        foreach (EffectedObject o in effectedObjects)
        {
            o.WhileActive(this);
        }
    }

    protected virtual void OnValueChange(float value)
    {
        foreach (EffectedObject o in effectedObjects)
        {
            o.OnValueChange(this, value);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;

        foreach (EffectedObject target in effectedObjects)
        {
            if (target)
            {
                Gizmos.DrawLine(transform.position, target.transform.position);
            }
        }
    }
}
