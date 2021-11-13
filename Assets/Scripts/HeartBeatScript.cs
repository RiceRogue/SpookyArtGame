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

    public AudioSource audio;

    

    // Start is called before the first frame update
    void Start()
    {
        heart = GetComponent<Image>();
        heart.fillAmount = 0;
        //heartState = 1; //the conditional
        heartThresh = 1; //threshold for each beat
        heartMeter = 0;
        heartMax = 51; //max
        heartBeat = 0; 
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        heartSpeed += Time.deltaTime;
        heartMeter += Time.deltaTime;

        if (heartMeter <= 20) //state 1: normal 
        {
            heartThresh = 1;
            
        }
        else if (21 <= heartMeter <= 35) //state 2: slightly fast 
        {
            heartThresh = .75;

        }
        else if (36 <= heartMeter <= 45) //state 3: fast 
        {
            heartThresh = .55;

        }
        else if (46 <= heartMeter <= 50) //state 4: HEY-YOURE-ABOUT-TO-DIE-fast 
        {
            heartThresh = .4;

        }
        else if (heartMeter == 51) //state 5: stroke and death
        {
            //game over

        }

        heartBeat = heartSpeed / heartThresh;
        heart.fillAmount = heartMeter / heartMax;

        heartPlay();


       

    }

    void heartPlay()
    {
        heartSpeed = heartThresh;

        audio.Play();
        heartSpeed = 0;
 
    }
}
