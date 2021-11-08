using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScream : MonoBehaviour
{

    public AudioSource scream;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        
    }

    public void ChangeVolume()
    {
        StartCoroutine(ChangeVolumeCoroutine());
    }

    private IEnumerator ChangeVolumeCoroutine()
    {
        while (scream.volume < 0.08)
        {
            scream.volume += 0.0003f;
            yield return null;
        }
    }
}
