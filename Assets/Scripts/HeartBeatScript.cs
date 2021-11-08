using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartBeatScript : MonoBehaviour
{
    public Image heart;
    public float heartSpeed;
    public float heartMax;

    

    // Start is called before the first frame update
    void Start()
    {
        heart = GetComponent<Image>();
        heart.fillAmount = 0;
        heartMax = Random.Range(60, 100);
    }

    // Update is called once per frame
    void Update()
    {

        heartSpeed++;
        heart.fillAmount = heartSpeed / heartMax;

        if (heart.fillAmount == 1)
        {
            heartSpeed = heartMax;


            heartSpeed = 0;

        }


       

    }
}
