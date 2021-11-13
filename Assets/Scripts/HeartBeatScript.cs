using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartBeatScript : MonoBehaviour
{
    public Image heart;
    public float heartSpeed;
    public float heartMax;
    public int heartState;
    public float heartBeat;

    public AudioSource audio;

    

    // Start is called before the first frame update
    void Start()
    {
        heart = GetComponent<Image>();
        heart.fillAmount = 0;
        heartState = 1;
        heartMax = 1;
        heartBeat = 0;
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        heartSpeed += Time.deltaTime;
        heartBeat = heartSpeed / heartMax;

        


       

    }

    void heartPlay()
    {
        if (heartBeat == 1)
        {
            heartSpeed = heartMax;

            audio.Play();
            heartSpeed = 0;

        }
    }
}
