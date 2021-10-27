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


    public bool resetScene;
    // Start is called before the first frame update
    void Start()
    {
        refPos = Vector3.zero;
        origin = gameObject.transform.position;
        randInt = Random.Range(5f, 10f);

        monster1Scream = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > randInt)
        {
            gameObject.transform.position = Vector3.SmoothDamp(gameObject.transform.position, Camera.main.transform.position,ref refPos,  3f);
            
        }

        if(resetPosition == true)
        {
            randInt = Random.Range(5f, 10f);
            timer = 0;
            gameObject.transform.position = origin;
            resetPosition = false;
        }

        if(resetScene == true)
        {
            timer2 += Time.deltaTime;
            if (timer2 > 2f)
            {
                SceneManager.LoadScene("Game");

            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == Camera.main.gameObject.name)
        {
            monster1Scream.Play();

            resetScene = true;

        }
    }
}
