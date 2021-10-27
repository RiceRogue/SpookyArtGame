using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public Vector3 original;

    public float yaw;
    public float pitch;

    public float horizontalSpeed;
    public float verticalSpeed;
    //public Vector


    // Start is called before the first frame update
    void Start()
    {
        original = transform.rotation.eulerAngles;

    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene("Game");
        }

        


        yaw += Input.GetAxis("Mouse X") * horizontalSpeed;
        pitch += Input.GetAxis("Mouse Y") * verticalSpeed;

        float newYaw = Mathf.Clamp(yaw, -3, 3);
        float newPitch = Mathf.Clamp(pitch, -20, 2);

        transform.eulerAngles = original + new Vector3(-newPitch, newYaw, 0.0f);





    }

    void FixedUpdate()
    {
        
    }

    
}

