using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Shift : MonoBehaviour
{
    private HashSet<Character> shiftableCharacters = new HashSet<Character>();
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && shiftableCharacters.Count > 0)
        {
            gameManager.setControlledObject(shiftableCharacters.First());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Character thisCharacter = this.GetComponent<Character>();
        if (thisCharacter.HasControl() && other.CompareTag("Character"))
        {
            shiftableCharacters.Add(other.GetComponent<Character>());

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Character"))
        {
            shiftableCharacters.Remove(other.GetComponent<Character>());
        }
    }
}