using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubberDuck : Character
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inControl)
        {
            bool shouldPlay =
            Input.GetKeyDown(KeyCode.E)
            || Input.GetKeyDown(KeyCode.W)
            || Input.GetKeyDown(KeyCode.S)
            || Input.GetKeyDown(KeyCode.A)
            || Input.GetKeyDown(KeyCode.D)
            || Input.GetKeyDown(KeyCode.E)
            || Input.GetKeyDown(KeyCode.Q)
            || Input.GetKeyDown(KeyCode.Space);


            if (shouldPlay)
            {
                AudioManager.instance.PlaySFX(AudioManager.instance.quack);
                animator.SetTrigger("RubberDuck1");
            }
            else
            {
                animator.ResetTrigger("RubberDuck1");
            }
        }        
    }
}
