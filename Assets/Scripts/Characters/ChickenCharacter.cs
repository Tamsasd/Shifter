using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Animator))]
public class ChickenCharacter : Character
{
    private Animator animator;
    [SerializeField] private GameObject featherEffect;
    private GameManager gameManager;

    void Start()
    {
        animator = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (inControl)
        {
            bool isMoving =
                Input.GetKey(KeyCode.W) ||
                Input.GetKey(KeyCode.S) ||
                Input.GetKey(KeyCode.A) ||
                Input.GetKey(KeyCode.D);

            if (isMoving)
            {
                animator.SetFloat("Vert", 1f);
                animator.SetFloat("State", 1f);
            }
            else
            {
                animator.SetFloat("Vert", 0f);
                animator.SetFloat("State", 0f);
            }
        }
        else
        {
            animator.SetFloat("Vert", 0f);
            animator.SetFloat("State", 0f);
        }

        if (transform.position.y < -50f)
        {
            Debug.Log(transform.position.y);
            Die();
        }
    }

    public void Die()
    {
        Instantiate(featherEffect, new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z), Quaternion.identity);
        Destroy(gameObject);

        gameManager.Lose();
    }
}