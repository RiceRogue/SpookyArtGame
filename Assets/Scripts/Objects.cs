using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Objects : MonoBehaviour
{
    public Ray mouseRay;
    public RaycastHit hit;
    public string hitName;



    //public Camera camera;

    public bool moveToYou;
    public bool movedObject;

    public TextMeshProUGUI cameraText;

    public Vector3 originalLocation;


    public Image flashImage;
    public float flashSpeed = 1.5f;
    //Time the flash lasts for
    public Color flashColour = new Color(1f, 1f, 1f, 1f);


    public GameObject monster1;
    // Start is called before the first frame update
    void Start()
    {
        moveToYou = false;
        originalLocation = transform.position;
        cameraText.enabled = false;
        flashImage.color = Color.clear;

    }

    // Update is called once per frame
    void Update()
    {
        mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(mouseRay, out hit))
        {
            hitName = hit.collider.name;
        }
        else
        {
            hitName = " ";
        }


        Monster1 monster1script = monster1.GetComponent<Monster1>();

        if (Input.GetKeyDown(KeyCode.E) && movedObject && gameObject.name == "CameraObject") { 
            flashImage.color = flashColour;
            monster1script.resetPosition = true;
            
        } else
        {
            flashImage.color = Color.Lerp(flashImage.color, Color.clear, flashSpeed * Time.deltaTime);



        }

    }
    void OnMouseDown()
    {
        if (hitName == "CameraObject" && moveToYou == false)
        {
            cameraText.enabled = true;
            hit.collider.GetComponent<Rigidbody>().position = Camera.main.gameObject.GetComponent<Rigidbody>().position + new Vector3(0, -0.1f, 0.45f);
            //gameObject.GetComponent<Rigidbody>().MovePosition(camera.transform.position + new Vector3(0, 0, 5f) * Time.deltaTime * 0.1f);
            movedObject = true;
            moveToYou = true;

        }
        else if (hitName == "CameraObject" && movedObject)
        {
            hit.collider.GetComponent<Rigidbody>().position = originalLocation;
            cameraText.enabled = false;
            moveToYou = false;
            movedObject = false;

        }




    }

}

    
