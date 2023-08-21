using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeadsetScript : MonoBehaviour
{
    public Ray mouseRay;
    public RaycastHit hit;
    public string hitName;

    public bool moveToYou;
    public bool movedObject;

    public Vector3 originalLocation;
    public Vector3 originalRotation;

    public Vector3 refPos;
    public AudioSource audio;

    public Image heartRate;

    public bool reducing;


    // Start is called before the first frame update
    void Start()
    {
        refPos = Vector3.zero;
        reducing = false;
        originalLocation = transform.position;
        originalRotation = transform.localEulerAngles;

    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.main.enabled == true)
        {
            mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        }
        if (Physics.Raycast(mouseRay, out hit))
        {
            hitName = hit.collider.name;
        }
        else
        {
            hitName = " ";
        }

        if (movedObject)
        {
            transform.localEulerAngles = Camera.main.transform.localEulerAngles;

            GetComponent<Rigidbody>().position = Vector3.Lerp(transform.position, Camera.main.transform.position + new Vector3(-0.3f, 0, .3f), 0.1f);
            //Vector3.Lerp(transform.position, Camera.main.transform.position + new Vector3(0, 1, 0), 0.1f);
        }

        /* if (Input.GetMouseButtonDown(0) && movedObject && moveToYou)

         {
             transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
             GetComponent<Rigidbody>().position = originalLocation;
             GetComponent<Rigidbody>().velocity = Vector3.zero;
             transform.localEulerAngles = originalRotation;

             moveToYou = false;
             movedObject = false;

         }*/

        if (GetComponent<Rigidbody>().position == originalLocation && movedObject == false)
        {
            //transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;

        }
        if (reducing)
        {
            heartRate.GetComponent<HeartBeatScript>().heartMeter -= Time.deltaTime * 2;

        }


        if (Vector3.Distance(transform.position, Camera.main.transform.position + new Vector3(-0.3f, 0, .3f)) < 0.1f)
        {
            AudioListener boof = Camera.main.transform.GetComponent<AudioListener>();
            AudioListener.volume = 0.1f;
            reducing = true;
            transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
            transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        }
        else
        {
            reducing = false;
            AudioListener.volume = 1f;

        }

    }


    void OnMouseDown()
    {
        if (hitName == "earmuff" && moveToYou == false)
        {
            audio.Play();
            //hit.collider.GetComponent<Rigidbody>().position = Vector3.SmoothDamp(gameObject.transform.position, Camera.main.transform.position + new Vector3(0, 0f, 0.1f), ref refPos, 3f);

            //hit.collider.GetComponent<Rigidbody>().position = Camera.main.gameObject.GetComponent<Rigidbody>().position + new Vector3(0.1f, -0.1f, 0f);
            //hit.collider.transform.localEulerAngles = Camera.main.transform.localEulerAngles;
            //gameObject.GetComponent<Rigidbody>().MovePosition(camera.transform.position + new Vector3(0, 0, 5f) * Time.deltaTime * 0.1f);
            movedObject = true;
            moveToYou = true;
            transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;



        }
        else if (hitName == "earmuff" && movedObject)
        {
            audio.Play();
            transform.localEulerAngles = originalRotation;
            transform.position = originalLocation + new Vector3(0, 0.03f, -0.1f);
            reducing = false;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            moveToYou = false;
            movedObject = false;

        }






    }


   
}
