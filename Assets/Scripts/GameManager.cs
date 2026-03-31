using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Character controlledObject;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        controlledObject.ToggleControl(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Character GetControlledObject()
    {
        return controlledObject;
    }
}
