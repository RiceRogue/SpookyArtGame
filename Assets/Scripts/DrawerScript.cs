using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerScript : MonoBehaviour
{
    public Ray mouseRay;
    public RaycastHit hit;
    public string hitName;

    public bool opened;
    public Vector3 origin;
    // Start is called before the first frame update
    void Start()
    {
        origin = transform.position;
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



    }

    void OnMouseDown()
    {
        if (hitName == "drawer1" && opened == false)
        {
            Debug.Log("YES");
            Vector3 moveLocation = origin + new Vector3(0, 0, -0.15f);
            hit.collider.GetComponent<Rigidbody>().position = moveLocation;
            opened = true;

        }
        else if (hitName == "drawer1" && opened == true)
        {
            hit.collider.GetComponent<Rigidbody>().position = origin;
            opened = false;

        }

    }
}
