using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Shift : MonoBehaviour
{
    private HashSet<Character> shiftableCharacters = new();
    private GameManager gameManager;
    

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F) && shiftableCharacters.Count > 0)
        {
            Character thisChar = gameManager.GetControlledObject();

            Character closest = shiftableCharacters
                .Where(c => c != thisChar)
                .OrderBy(c => Vector3.Distance(transform.position, c.transform.position))
                .FirstOrDefault();

            if (closest != null)
            {
                gameManager.setControlledObject(closest);
                shiftableCharacters.Clear();
            }
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            if (gameManager.GetControlledObject() != gameManager.GetMainCharacter())
            {
                gameManager.setControlledObject(gameManager.GetMainCharacter());
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Character otherChar = other.GetComponentInParent<Character>();

        if (otherChar != null && otherChar.gameObject.CompareTag("Character"))
        {
            shiftableCharacters.Add(otherChar);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Character otherChar = other.GetComponentInParent<Character>();

        if (otherChar != null && otherChar.gameObject.CompareTag("Character"))
        {
            shiftableCharacters.Remove(otherChar);
        }
    }
}