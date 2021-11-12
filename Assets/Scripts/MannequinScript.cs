using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MannequinScript : MonoBehaviour
{
    public GameObject cameraControl;
    public CameraController camControlScript;

    public Rigidbody rgb;
    public float moveSpeed;

    public Vector3 originRotation;
    public Vector3 origin;

    public Ray mouseRay;
    public RaycastHit hit;
    public string hitName;
    public GameObject destination;

    public GameObject box1;
    public GameObject box2;
    public GameObject box3;

    public AudioSource deathSound;
    public bool resetScene;

    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        originRotation = transform.localEulerAngles;
        origin = transform.position;
        rgb = GetComponent<Rigidbody>();
        camControlScript = cameraControl.GetComponent<CameraController>();
        destination = box1;
    }

    // Update is called once per frame
    void Update()
    {

        if(transform.position == origin)
        {
            destination = box1;
            box1.GetComponent<BoxCollider>().enabled = true;
            box2.GetComponent<BoxCollider>().enabled = true;
            box3.GetComponent<BoxCollider>().enabled = true;



        }


        if (camControlScript.lookingLeft == true)
        {
            Vector3 direction = (destination.transform.position - transform.position).normalized;

            rgb.MovePosition(transform.position + direction * moveSpeed * Time.deltaTime);
            Quaternion desiredRotation = Quaternion.Euler(0, -220f, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, 2.5f * moveSpeed * Time.deltaTime);

        }
        //IE Looking in the middle or away from the mannequin.
        else if (camControlScript.lookingLeft == false && camControlScript.lookingRight == false)
        {
            Vector3 direction = (destination.transform.position - transform.position).normalized;
            rgb.MovePosition(transform.position + direction * moveSpeed * Time.deltaTime);
            Quaternion desiredRotation = Quaternion.Euler(0, -220f, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, 2.5f * moveSpeed * Time.deltaTime);

        }
        else
        {
            //Do nothing
        }


        if (resetScene == true)
        {

            timer += Time.deltaTime;
            if (timer > 2.5f)
            {
                SceneManager.LoadScene("Game");

            }
        }





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
    }

    void OnMouseDown()
    {

        Vector3 direction = (origin - transform.position).normalized;
        rgb.MovePosition(transform.position + direction * moveSpeed * 15f * Time.deltaTime);


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == box1.name)
        {
            destination = box2;
            box1.GetComponent<BoxCollider>().enabled = false;

        } else if (collision.gameObject.name == box2.name)
        {
            destination = box3;
            box2.GetComponent<BoxCollider>().enabled = false;

        } else if (collision.gameObject.name == box3.name)
        {
            destination = cameraControl;
            box3.GetComponent<BoxCollider>().enabled = false;

        } else if (collision.gameObject.name == cameraControl.name)
        {
            deathSound.Play();
            resetScene = true;

        }

    }
}
