using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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


    public float timer2;
    

    // Start is called before the first frame update
    void Start()
    {
        heart = GetComponent<Image>();
        heart.fillAmount = 0;
        //heartState = 1; //the conditional
        heartThresh = 1f; //threshold for each beat
        heartMeter = 0f;
        heartMax = 100f; //max
        heartBeat = 0f; 
        audio = GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {
        if(heartMeter <= 0)
        {
            heartMeter = 0;
        }

        heartSpeed += Time.deltaTime;
        //heartMeter += Time.deltaTime;

        if (heartMeter <= 40) //state 1: normal 
        {
            heartThresh = 1f;
            
        }
        else if (41 <= heartMeter && heartMeter <= 70) //state 2: slightly fast 
        {
            heartThresh = .75f;

        }
        else if (71 <= heartMeter && heartMeter <= 90) //state 3: fast 
        {
            heartThresh = .55f;

        }
        else if (91 <= heartMeter && heartMeter <= 100) //state 4: HEY-YOURE-ABOUT-TO-DIE-fast 
        {
            heartThresh = .4f;

        }
        else if (heartMeter >= 101) //state 5: stroke and death
        {
            //game over
            timer2 += Time.deltaTime;
            if (timer2 > 2.5f)
            {
                SceneManager.LoadScene("HeartDeath");

            }


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
        heartMeter++;
 
    }
}
