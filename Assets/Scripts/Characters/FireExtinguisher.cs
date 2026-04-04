using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExtinguisher : Character
{
    private void Update()
    {
        playSoundOnMove(KeyCode.Space);
    }
}
