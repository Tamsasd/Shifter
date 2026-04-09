using UnityEngine;

public abstract class EffectedObject : MonoBehaviour
{
    public abstract void OnActivate();

    public abstract void OnDeactivate();

    public abstract void WhileActive();
}
