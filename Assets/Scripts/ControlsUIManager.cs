using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ControlsUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    public bool shiftable = false;
    public bool chicken = true;

    private void Awake()
    {
        chicken = true;
    }

    void Start()
    {
        SetHUD(true, true, true); // call for chicken at loading the scene
    }

    
    void Update()
    {
        
    }

    public void SetHUD(bool canMove, bool canRotate, bool canJump, string extraHUDText = "")
    {
        string newText = "P: pause\n";
        //newText += "F: turn into targetted object\n";
        //newText += "R: return to chicken\n";

        if (shiftable) newText += "F: turn into targetted object\n";
        if (!chicken) newText += "R: return to chicken\n";

        if (canMove) newText += "WASD: move\n";
        if (canRotate) newText += "Q, E: rotate\n";
        if (canJump) newText += "Space: jump\n";

        if (!string.IsNullOrEmpty(extraHUDText))
        {
            newText += extraHUDText + "\n";
        }

        text.SetText(newText);
    }
}
