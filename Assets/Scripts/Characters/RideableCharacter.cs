using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RideableCharacter : Character
{
    private FreezeArea freezeArea;

    public override void ToggleControl(bool value)
    {
        base.ToggleControl(value);
        freezeArea.ToggleFreeze(value);
    }

    private void Start()
    {
        freezeArea = GetComponentInChildren<FreezeArea>();
    }
}
