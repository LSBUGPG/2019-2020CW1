using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    public Text theTimer;
    public float startTime = 50f;
    public float currentTime;





    public GameObject dialogue;


    // Start is called before the first frame update
    void Start()
    {
        currentTime = startTime;
        theTimer.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime >= 0 && dialogue.GetComponent<Dialogue>().sentenceOver == true)

        {
            theTimer.enabled = true;
            currentTime -= 1 * Time.deltaTime;
            theTimer.text = currentTime.ToString("0");
        }


       
    }
}
