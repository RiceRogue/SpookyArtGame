using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager2 : MonoBehaviour
{

    public AudioSource Music;
    public AudioSource ambience;
    // Start is called before the first frame update
    void Start()
    {
        ambience.Play();
        Music.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
