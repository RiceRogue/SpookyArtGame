using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public GameObject camera;
    public float rotationSpeed;
    public Image leftArrow;
    public Image rightArrow;


    public bool lookingLeft;
    public bool lookingRight;

    public float rotateSize;
    public float rotateOriginal;

    public float yaw;
    public float pitch;

    public float horizontalSpeed;
    public float verticalSpeed;
    //public Vector


    // Start is called before the first frame update
    void Start()
    {
        
        rotateOriginal = camera.transform.rotation.y;

    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene("Game");
        }

        //Camera Controls for when you can and cannot look left and right. 
        if (Input.GetKeyUp(KeyCode.LeftArrow) && lookingLeft == false && lookingRight == false)
        {
            camera.transform.rotation = Quaternion.Euler(new Vector3(0, camera.transform.rotation.y - rotateSize, 0));
            leftArrow.gameObject.SetActive(false);
            lookingLeft = true;
            //Trying smooth camra movement, and failed
            //camera.transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.Euler(new Vector3(0,0, -0.3f)), 0.1f);
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow) && lookingRight == true)
        {
            camera.transform.rotation = Quaternion.Euler(new Vector3(0, rotateOriginal, 0));
            rightArrow.gameObject.SetActive(true);
            lookingRight = false;
            //camera.transform.rotation = Quaternion.Lerp(transform.rotation,  Quaternion.Euler(new Vector3(0, 0, -0.3f)), 0.1f);
        }


        if (Input.GetKeyUp(KeyCode.RightArrow) && lookingRight == false && lookingLeft == false)
        {
            camera.transform.rotation = Quaternion.Euler(new Vector3(0, camera.transform.rotation.y + rotateSize, 0));
            rightArrow.gameObject.SetActive(false);
            lookingRight = true;
            //camera.transform.rotation = Quaternion.Lerp(transform.rotation,  Quaternion.Euler(new Vector3(0, 0, -0.3f)), 0.1f);
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow) && lookingLeft == true)
        {

            camera.transform.rotation = Quaternion.Euler(new Vector3(0, rotateOriginal, 0));
            leftArrow.gameObject.SetActive(true);
            lookingLeft = false;
            //camera.transform.rotation = Quaternion.Lerp(transform.rotation,  Quaternion.Euler(new Vector3(0, 0, -0.3f)), 0.1f);
        }


        yaw += Input.GetAxis("Mouse X") * horizontalSpeed;
        pitch += Input.GetAxis("Mouse Y") * verticalSpeed;

        float newYaw = Mathf.Clamp(yaw, -3, 3);
        float newPitch = Mathf.Clamp(pitch, -20, 2);

        transform.eulerAngles = new Vector3(-newPitch, newYaw, 0.0f);





    }

    void FixedUpdate()
    {
        
    }

    
}

