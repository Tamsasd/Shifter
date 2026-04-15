using UnityEngine;

public abstract class EffectedObject : MonoBehaviour
{
    public abstract void OnActivate(Interactable effector);

    public abstract void OnDeactivate(Interactable effector);

    public abstract void WhileActive(Interactable effector);

    public abstract void OnValueChange(Interactable effector, float value);
}
