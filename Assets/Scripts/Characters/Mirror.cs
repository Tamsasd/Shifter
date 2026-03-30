using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    private Transform mainCameraTransform;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        mainCameraTransform = GameObject.FindWithTag("MainCamera").GetComponent<Transform>();
        offset = mainCameraTransform.rotation.eulerAngles - transform.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 parentRotation = transform.parent.transform.rotation.eulerAngles;
        Quaternion rot = Quaternion.Euler(new Vector3(0,180,0) - parentRotation + mainCameraTransform.rotation.eulerAngles - offset * -1f);
        gameObject.transform.rotation = rot;
        
    }
}
