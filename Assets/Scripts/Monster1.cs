using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;


public class Monster1: MonoBehaviour
{

    public float timer;
    public float timer2;

    public float randInt;

    public Vector3 refPos;

    public bool resetPosition;
    public Vector3 origin;

    public AudioSource monster1Scream;
    public AudioSource deathSound;

    public GameObject lungeBox;


    public bool resetScene;
    public bool pursue;
    public bool lunge;
    // Start is called before the first frame update
    void Start()
    {
        refPos = Vector3.zero;
        origin = gameObject.transform.position;
        randInt = Random.Range(20f, 30f);

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > randInt || pursue == true)
        {
            pursue = true;
            timer = 0;
            gameObject.transform.position = Vector3.SmoothDamp(gameObject.transform.position, Camera.main.transform.position,ref refPos,  3f);
        }

        if(resetPosition == true)
        {
            randInt = Random.Range(10f, 30f);
            timer = 0;
            timer2 = 0;
            lungeBox.GetComponent<BoxCollider>().enabled = true;
            gameObject.transform.position = origin;
            resetPosition = false;
        }

        if(resetScene == true)
        {
            timer2 += Time.deltaTime;
            if (timer2 > 2.5f)
            {
                SceneManager.LoadScene("Game");

            }
        }

        if (lunge == true)
        {
            timer2 += Time.deltaTime;
            if (timer2 > 4f)
            {
                lungeBox.GetComponent<BoxCollider>().enabled = false;
                pursue = true;
                lunge = false;
                timer2 = 0;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == Camera.main.gameObject.name)
        {
            deathSound.Play();
            
            resetScene = true;

        }
        else if (collision.gameObject.name == lungeBox.name){

            //pursue = false;
            monster1Scream.Play();
            lunge = true;
        }

    }
}
