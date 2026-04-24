using UnityEngine;

public class Mover : EffectedObject
{
    [SerializeField] private Vector3 start;
    [SerializeField] private Vector3 end;
    [SerializeField] private float transitionTime;

    private float currentProgress = 0f;
    private float targetProgress = 0f;

    [ContextMenu("Set Current as Start")]
    private void SetCurrentAsStart()
    {
        start = transform.localPosition;
    }

    [ContextMenu("Set Current as End")]
    private void SetCurrentAsEnd()
    {
        end = transform.localPosition;
    }

    [ContextMenu("Snap to Start")]
    private void SnapToStart()
    {
        transform.localPosition = start;
    }

    [ContextMenu("Snap to End")]
    private void SnapToEnd()
    {
        transform.localPosition = end;
    }

    public override void OnActivate(Interactable effector)
    {
        targetProgress = 1f;
    }

    public override void OnDeactivate(Interactable effector)
    {
        targetProgress = 0f;
    }

    public override void OnValueChange(Interactable effector, float value)
    {
        return;
    }
    public override void WhileActive(Interactable effector)
    {
        return;
    }

    void Update()
    {
        float step = Time.deltaTime / transitionTime;

        currentProgress = Mathf.MoveTowards(currentProgress, targetProgress, step);

        transform.position = Vector3.Lerp(start, end, currentProgress);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(start, end);
    }
}