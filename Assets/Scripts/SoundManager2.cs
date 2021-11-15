using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager2 : MonoBehaviour
{

   


    public float timerMannequin;
    public float timerPortrait;
    public float timerScream;

    public GameObject MonsterPortrait;
    public GameObject MonsterMannequin;
    public GameObject MonsterScream;

    public Monster1 mon;
    public MannequinScript man; //save dd
    public MonsterScream scm;
    public Animator anim; 
    public Animator animscream; 
    public float clocktimer;


    // Start is called before the first frame update
    void Start()
    {
        mon = MonsterPortrait.GetComponent<Monster1>();
        man = MonsterMannequin.GetComponent<MannequinScript>();
        scm = MonsterScream.GetComponent<MonsterScream>();
        animscream.speed = 0f; 
        anim.speed = 0f; 
        mon.enabled = false;
        man.enabled = false;
        scm.enabled = false;

        clocktimer = 0;


    }

    // Update is called once per frame
    void Update()
    {

        clocktimer += Time.deltaTime;

        timerMannequin += Time.deltaTime;
        timerPortrait += Time.deltaTime;
        timerScream += Time.deltaTime;


        if(timerMannequin > 30f)
        {
            man.enabled = true;
        }

        if (timerScream > 60f)
        {
            scm.enabled = true;
            animscream.speed = 1f;

        }

        if (timerPortrait > 90f)
        {
            mon.enabled = true;
            anim.speed = 1f; 
        }


        if(clocktimer > 300f)
        {
            SceneManager.LoadScene("TimeDeath");
        }

    }
}
