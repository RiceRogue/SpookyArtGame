using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkingUI : MonoBehaviour
{
    public Image blink;
    public float blinkSpeed;
    public float blinkMax;

    public float eyelidSpeed;
    public float eyelidMax;

    

    public Image eyelid1;
    public Image eyelid2;

    public bool closeEyelids;
    // Start is called before the first frame update
    void Start()
    {
        blink = GetComponent<Image>();
        blink.fillAmount = 0;
        eyelid1.fillAmount = 0 ;
        eyelid2.fillAmount = 0;

    }

    // Update is called once per frame
    void Update()


    {

        blinkSpeed++;
        blink.fillAmount = blinkSpeed/blinkMax;
        
        if(blink.fillAmount == 1)
        {
            blinkSpeed = blinkMax;

            eyelidSpeed++;
            
            eyelid1.fillAmount = eyelidSpeed / eyelidMax;
            eyelid2.fillAmount = eyelidSpeed / eyelidMax;

            if(eyelid1.fillAmount == 1 && eyelid2.fillAmount == 1)
            {

                closeEyelids = true;
                blinkSpeed = 0;
            }

            
        }


        if (closeEyelids)
        {
            blink.fillAmount = 0;
            eyelidSpeed--;
            eyelid1.fillAmount = eyelidSpeed / eyelidMax;
            eyelid2.fillAmount = eyelidSpeed / eyelidMax;

            if(eyelid1.fillAmount == 0 && eyelid2.fillAmount == 0)
            {
                closeEyelids = false;
            }

        }
    }
}
