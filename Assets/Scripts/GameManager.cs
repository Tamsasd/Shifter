using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Character controlledObject;
    [SerializeField] private Character mainCharacter;

    // Start is called before the first frame update
    void Start()
    {
        controlledObject = mainCharacter;
        controlledObject.ToggleControl(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setCursorLock(bool isLocked)
    {

        Cursor.lockState = isLocked ? CursorLockMode.Locked : CursorLockMode.Confined;
        Cursor.visible = !isLocked; // giga
    }

    public Character GetControlledObject()
    {
        return controlledObject;
    }

    public Character GetMainCharacter()
    {
        return mainCharacter;
    }

    public void setControlledObject(Character controlledObject)
    {
        this.controlledObject.ToggleControl(false);
        this.controlledObject = controlledObject;
        this.controlledObject.DisableOutline();
        this.controlledObject.ToggleControl(true);
    }
}
