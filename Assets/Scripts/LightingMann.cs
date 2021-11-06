using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingMann : MonoBehaviour
{
    public GameObject mannequin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPosition = transform.position;
        currentPosition.x = mannequin.transform.position.x - 0.2f;
        currentPosition.z = mannequin.transform.position.z - 0.22f;

        transform.position = currentPosition;
    }
}
