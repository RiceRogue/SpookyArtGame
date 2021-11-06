using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Minus))
        {
            SceneManager.LoadScene("Morning2");
        } else if (Input.GetKeyDown(KeyCode.Equals))
        {
            SceneManager.LoadScene("Game");
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
