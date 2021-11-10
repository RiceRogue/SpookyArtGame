using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScream : MonoBehaviour
{

    public AudioSource scream;

    public int maxVol;
    public int vol;

    public bool screamo;

    // Start is called before the first frame update
    void Start()
    {
        scream = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {


        if(scream.volume < 0.03 && screamo == false)
        {
            scream.Play();
            scream.volume += 0.00005f; 
            
        } else if (scream.volume > 0.0)
        {
            screamo = true;
            scream.Play();
            scream.volume -= 0.00005f;
        } else if (scream.volume == 0 && screamo == true)
        {
            screamo = false;
        }

    }

    public void ChangeVolume()
    {
    }

  
}
