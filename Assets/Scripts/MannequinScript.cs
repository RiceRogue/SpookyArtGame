using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MannequinScript : MonoBehaviour
{
    public GameObject cameraControl;
    public CameraController camControlScript;

    public Rigidbody rgb;
    public float moveSpeed;

    public Vector3 originRotation;
    public Vector3 origin;
    // Start is called before the first frame update
    void Start()
    {
        originRotation = transform.localEulerAngles;
        origin = transform.position;
        rgb = GetComponent<Rigidbody>();
        camControlScript = cameraControl.GetComponent<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {

        if(camControlScript.lookingLeft == true)
        {
            Vector3 direction = (cameraControl.transform.position - transform.position).normalized;

            rgb.MovePosition(transform.position + direction * moveSpeed * Time.deltaTime);
            Quaternion desiredRotation = Quaternion.Euler(0, -220f, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, 2.5f * moveSpeed * Time.deltaTime);

        }
        //IE Looking in the middle or away from the mannequin.
        else if (camControlScript.lookingLeft == false && camControlScript.lookingRight == false)
        {
            Vector3 direction = (cameraControl.transform.position - transform.position).normalized;
            rgb.MovePosition(transform.position + direction * moveSpeed * Time.deltaTime);
            Quaternion desiredRotation = Quaternion.Euler(0, -220f, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, 2.5f * moveSpeed * Time.deltaTime);

        }
        else
        {
            //Do nothing
        }
    }
}
