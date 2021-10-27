using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CameraController : MonoBehaviour
{
    public GameObject cameraLeft;
    public GameObject cameraRight;
    public GameObject cameraMain;

    public bool lookingLeft;
    public bool lookingRight;

    public Image leftArrow;
    public Image rightArrow;

    public float rotateSize;
    public float rotateOriginal;

    // Start is called before the first frame update
    void Start()
    {
        cameraLeft.SetActive(false);
        cameraRight.SetActive(false); 
        
    }

    // Update is called once per frame
    void Update()
    {

        //Camera Controls for when you can and cannot look left and right. 
        if (Input.GetKeyUp(KeyCode.LeftArrow) && lookingLeft == false && lookingRight == false)
        {
            cameraLeft.SetActive(true);
            cameraMain.SetActive(false);
            cameraRight.SetActive(false);
            leftArrow.gameObject.SetActive(false);
            lookingLeft = true;
            
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow) && lookingRight == true)
        {
            cameraMain.SetActive(true);
            cameraRight.SetActive(false);
            cameraLeft.SetActive(false);
            rightArrow.gameObject.SetActive(true);
            lookingRight = false;
            //camera.transform.rotation = Quaternion.Lerp(transform.rotation,  Quaternion.Euler(new Vector3(0, 0, -0.3f)), 0.1f);
        }


        if (Input.GetKeyUp(KeyCode.RightArrow) && lookingRight == false && lookingLeft == false)
        {
            cameraRight.SetActive(true);
            cameraMain.SetActive(false);
            cameraLeft.SetActive(false);
            rightArrow.gameObject.SetActive(false);
            lookingRight = true;
            //camera.transform.rotation = Quaternion.Lerp(transform.rotation,  Quaternion.Euler(new Vector3(0, 0, -0.3f)), 0.1f);
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow) && lookingLeft == true)
        {
            cameraMain.SetActive(true);
            cameraLeft.SetActive(false);
            cameraRight.SetActive(false);
            leftArrow.gameObject.SetActive(true);
            lookingLeft = false;
            //camera.transform.rotation = Quaternion.Lerp(transform.rotation,  Quaternion.Euler(new Vector3(0, 0, -0.3f)), 0.1f);
        }

    }
}
