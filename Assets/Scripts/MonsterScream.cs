using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterScream : MonoBehaviour
{

    public AudioSource scream;
    public Animator anim;

    

    public bool screamo;
    public Image HeartRate;
    public float timer2;

    // Start is called before the first frame update
    void Start()
    {
        scream = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
        HeartBeatScript hbs = HeartRate.GetComponent<HeartBeatScript>();

        if(scream.volume < 0.5 && screamo == false)
        {
            anim.speed = 1;
            timer2 += Time.deltaTime;
            if (timer2 > 5f || timer2 == 0)
            {
                scream.Play();
                timer2 = 0;
            }
            scream.volume += 0.0005f;
            hbs.heartSpeed += 0.001f;
            hbs.heartMeter += 0.001f;


        }
        else if (scream.volume >= 0.5 && screamo == false )
        {
        
            screamo = true;
          
        } else if (screamo == true && scream.volume <= 0.6 && scream.volume >= 0.12)
        {
            anim.speed = 1;
            scream.Play();
            scream.volume -= 0.001f;
            
        } else if (scream.volume >= 0.1 && screamo == true ) 
        {
            anim.speed = 0; 
            screamo = false; 


        }
    

    

    }

    public void ChangeVolume()
    {
    }

  
}
