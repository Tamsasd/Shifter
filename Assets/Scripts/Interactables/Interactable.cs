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
            o.OnActivate();
        }
    }

    protected virtual void OnDeactivate()
    {
        foreach (EffectedObject o in effectedObjects)
        {
            o.OnDeactivate();
        }
    }

    protected virtual void WhileActive()
    {
        foreach (EffectedObject o in effectedObjects)
        {
            o.WhileActive();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;

        foreach (EffectedObject target in effectedObjects)
        {
            Gizmos.DrawLine(transform.position, target.transform.position);
        }
    }
}
