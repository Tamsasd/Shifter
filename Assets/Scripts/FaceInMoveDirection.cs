using System.Collections.Generic;
using UnityEngine;

public class FaceInMoveDirection : MonoBehaviour
{
    [SerializeField] private AbstractMove move;
    [SerializeField] private Character character;

    public float pivotSpeed = 10f;

    void OnValidate()
    {
        if (move == null)
        {
            move = GetComponent<AbstractMove>();
        }
        if (character == null)
        {
            character = move.GetComponent<Character>();
        }
        
    }

    void Update()
    {
        if (character.HasControl())
        {
            Turn();
        }
    }

    void Turn()
    {
        Vector3 moveDir = move.GetMoveDirection();

        if (moveDir.sqrMagnitude > 0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDir);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * pivotSpeed);
        }
    }
}