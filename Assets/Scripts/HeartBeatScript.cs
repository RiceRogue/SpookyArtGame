using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartBeatScript : MonoBehaviour
{
    public Image heart;
    public float heartSpeed;
    public float heartThresh;
    public float heartMax;
    public float heartMeter;
    public int heartState;
    public float heartBeat;

    public bool accel = false;

    public AudioSource audio;

    

    // Start is called before the first frame update
    void Start()
    {
        heart = GetComponent<Image>();
        heart.fillAmount = 0;
        //heartState = 1; //the conditional
        heartThresh = 1f; //threshold for each beat
        heartMeter = 0f;
        heartMax = 51f; //max
        heartBeat = 0f; 
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        heartSpeed += Time.deltaTime;
        heartMeter += Time.deltaTime;

        if (heartMeter <= 20) //state 1: normal 
        {
            heartThresh = 1f;
            
        }
        else if (21 <= heartMeter && heartMeter <= 35) //state 2: slightly fast 
        {
            heartThresh = .75f;
            Debug.Log("YES");

        }
        else if (36 <= heartMeter && heartMeter <= 45) //state 3: fast 
        {
            heartThresh = .55f;

        }
        else if (46 <= heartMeter && heartMeter <= 50) //state 4: HEY-YOURE-ABOUT-TO-DIE-fast 
        {
            heartThresh = .4f;

        }
        else if (heartMeter == 51) //state 5: stroke and death
        {
            //game over

        }

        heartBeat = heartSpeed / heartThresh;
        heart.fillAmount = heartMeter / heartMax;

        if(heartSpeed >= heartThresh)
        {
            heartPlay();
        }
        


       

    }

    void heartPlay()
    {
        audio.Play();
        heartSpeed = 0f;
 
    }
}
