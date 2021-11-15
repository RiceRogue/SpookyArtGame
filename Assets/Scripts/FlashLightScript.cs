using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FlashLightScript : MonoBehaviour
{
    public Ray mouseRay;
    public RaycastHit hit;
    public string hitName;



    //public Camera camera;

    public bool moveToYou;
    public bool movedObject;

    public TextMeshProUGUI cameraText;

    public Vector3 originalLocation;


    public float flashSpeed = 1.5f;
    //Time the flash lasts for
    public Color flashColour = new Color(1f, 1f, 1f, 1f);


    public GameObject monster1;
    public GameObject landingZone;

    public AudioSource click;
    // Start is called before the first frame update
    void Start()
    {
        moveToYou = false;
        originalLocation = transform.position;
        cameraText.enabled = false;

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


        Monster1 monster1script = monster1.GetComponent<Monster1>();

        /*if (Input.GetKey(KeyCode.E) && movedObject && gameObject.name == "FlashLight")
        {
            flashImage.color = flashColour;
            monster1script.resetPosition = true;

        }
        else
        {
            flashImage.color = Color.Lerp(flashImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }*/

        if (movedObject)
        {
            transform.localEulerAngles = Camera.main.transform.localEulerAngles;
        }

        if (Input.GetKey(KeyCode.Space) && movedObject && gameObject.name == "FlashLight")
        {
            gameObject.GetComponentInChildren<Light>().enabled = true;

            if (monster1script.lunge == true || monster1script.pursue == true)
            {
                monster1script.resetPosition = true;
            }

        }

        
        else
        {
            gameObject.GetComponentInChildren<Light>().enabled = false;

        }
    }
    void OnMouseDown()
    {
        if (hitName == "FlashLight" && moveToYou == false)
        {
            click.Play();
            cameraText.enabled = true;
            hit.collider.GetComponent<Rigidbody>().position = Camera.main.gameObject.GetComponent<Rigidbody>().position + new Vector3(0.2f, -0.1f, 0.45f);
            hit.collider.transform.localEulerAngles = Camera.main.transform.localEulerAngles;
            //gameObject.GetComponent<Rigidbody>().MovePosition(camera.transform.position + new Vector3(0, 0, 5f) * Time.deltaTime * 0.1f);
            movedObject = true;
            moveToYou = true;

        }
        else if (hitName == "FlashLight" && movedObject)
        {
            click.Play();
            hit.collider.transform.localEulerAngles = new Vector3(1f, 2f, -2f);
            hit.collider.GetComponent<Rigidbody>().position = landingZone.transform.position + new Vector3(0, 0.03f, -0.1f);
            cameraText.enabled = false;
            moveToYou = false;
            movedObject = false;

        }




    }

}


