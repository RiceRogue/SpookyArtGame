using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonScript : MonoBehaviour
{
    public GameObject camera;
    public float rotationSpeed;
    public Button leftbtn;
    public Button rightbtn;

    public bool lookingLeft;
    public bool lookingRight;

    public float rotateSize;
    public float rotateOriginal;


    // Start is called before the first frame update
    void Start()
    {

        rotateOriginal = camera.transform.rotation.y;

        leftbtn.onClick.AddListener(TaskOnClick1);

        rightbtn.onClick.AddListener(TaskOnClick2);
    }

    // Update is called once per frame
    void Update()
    {


    }

    void TaskOnClick1()
    {

        var buttonClicked = EventSystem.current.currentSelectedGameObject;


        if (buttonClicked.name == "LeftButton" && lookingLeft == false && lookingRight == false)
        {
            camera.transform.rotation = Quaternion.Euler(new Vector3(0, camera.transform.rotation.y - rotateSize, 0));
            leftbtn.gameObject.SetActive(false);
            lookingLeft = true;
            //Trying smooth camra movement, and failed
            //camera.transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.Euler(new Vector3(0,0, -0.3f)), 0.1f);
        }
        else if (buttonClicked.name == "LeftButton" && lookingRight == true)
        {
            camera.transform.rotation = Quaternion.Euler(new Vector3(0, rotateOriginal, 0));
            rightbtn.gameObject.SetActive(true);
            lookingRight = false;
            //camera.transform.rotation = Quaternion.Lerp(transform.rotation,  Quaternion.Euler(new Vector3(0, 0, -0.3f)), 0.1f);
        }


    }

    void TaskOnClick2()
    {
        var buttonClicked = EventSystem.current.currentSelectedGameObject;

        if (buttonClicked.name == "RightButton" && lookingRight == false && lookingLeft == false)
        {
            camera.transform.rotation = Quaternion.Euler(new Vector3(0, camera.transform.rotation.y + rotateSize, 0));
            rightbtn.gameObject.SetActive(false);
            lookingRight = true;
            //camera.transform.rotation = Quaternion.Lerp(transform.rotation,  Quaternion.Euler(new Vector3(0, 0, -0.3f)), 0.1f);
        }
        else if (buttonClicked.name == "RightButton" && lookingLeft == true)
        {

            camera.transform.rotation = Quaternion.Euler(new Vector3(0, rotateOriginal, 0));
            leftbtn.gameObject.SetActive(true);
            lookingLeft = false;
            //camera.transform.rotation = Quaternion.Lerp(transform.rotation,  Quaternion.Euler(new Vector3(0, 0, -0.3f)), 0.1f);
        }

    }
}
