using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeArea : MonoBehaviour
{
    private HashSet<Character> freezeableCharacters = new();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Character>(out Character character))
        { 
            freezeableCharacters.Add(character);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Character>(out Character character))
        {
            freezeableCharacters.Remove(character);
        }
    }

    public void ToggleFreeze(bool value)
    {
        if (value) { EnableFreeze(); }
        else { DisableFreeze(); }        
    } 

    private void EnableFreeze()
    {
        foreach (var character in freezeableCharacters)
        {
            character.transform.SetParent(transform, true);
            character.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    private void DisableFreeze()
    {
        foreach (var character in freezeableCharacters)
        {
            character.transform.SetParent(null);
            character.GetComponent<Rigidbody>().isKinematic = false;
        }
    }


}
