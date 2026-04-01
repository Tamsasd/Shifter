using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Shift : MonoBehaviour
{
    private HashSet<Character> shiftableCharacters = new();
    private GameManager gameManager;
    private List<Renderer> targetRenderers = new();
    [SerializeField] private int outlineLayerIndex = 1;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        targetRenderers = new List<Renderer>(GetComponentsInChildren<Renderer>());
    }

    void Update()
    {
        Character thisChar = GetComponent<Character>();

        if (thisChar.HasControl() && Input.GetKeyDown(KeyCode.F) && shiftableCharacters.Count > 0)
        {
            Character closest = shiftableCharacters
                .Where(c => c != thisChar)
                .OrderBy(c => Vector3.Distance(transform.position, c.transform.position))
                .FirstOrDefault();

            if (closest != null)
            {
                gameManager.setControlledObject(closest);
                OnControlLost();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Character thisCharacter = GetComponent<Character>();

        if (thisCharacter.HasControl() && other.CompareTag("Character"))
        {
            if (other.TryGetComponent(out Shift otherShift) && other.TryGetComponent(out Character otherChar))
            {
                shiftableCharacters.Add(otherChar);
                otherShift.EnableOutline();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Character thisCharacter = GetComponent<Character>();

        if (thisCharacter.HasControl() && other.CompareTag("Character"))
        {
            if (other.TryGetComponent(out Shift otherShift) && other.TryGetComponent(out Character otherChar))
            {
                shiftableCharacters.Remove(otherChar);
                otherShift.DisableOutline();
            }
        }
    }

    public void EnableOutline()
    {
        foreach (Renderer renderer in targetRenderers)
        {
            renderer.renderingLayerMask |= (1u << outlineLayerIndex);
        }
    }

    public void DisableOutline()
    {
        foreach (Renderer renderer in targetRenderers)
        {
            renderer.renderingLayerMask &= ~(1u << outlineLayerIndex);
        }
    }

    public void OnControlLost()
    {
        foreach (var character in shiftableCharacters)
        {
            if (character.TryGetComponent(out Shift otherShift))
            {
                otherShift.DisableOutline();
            }
        }
        shiftableCharacters.Clear();
    }
}