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
            scream.volume += 0.00005f;
            hbs.heartSpeed += 0.001f;
            hbs.heartMeter += 0.001f;


        }
        else if (scream.volume > 0.0)
        {
            anim.speed = 1;
            screamo = true;
            scream.Play();
            scream.volume -= 0.00005f;
        } else if (scream.volume == 0 && screamo == true)
        {
            screamo = false;
            anim.speed = 0;
            
        }

    }

    public void ChangeVolume()
    {
    }

  
}
