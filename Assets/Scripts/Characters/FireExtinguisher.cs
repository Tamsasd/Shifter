using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExtinguisher : Character
{
    public string extraHUDText = "Space: fly";
    private void Update()
    {
        playSoundOnMove(KeyCode.Space);
    }
}
