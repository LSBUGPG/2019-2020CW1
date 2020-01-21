using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Dialogue : MonoBehaviour
{
    public Text dialogueText;
    public string[] sentences;
    private int index;
    public float typingSpeed = 0.02f;
    public GameObject continueButton;



    public GameObject dialogueCanvas;
    public bool sentenceOver;
    public Text scoreText;
    public GameObject failedText;
    public Text Timer;
    public GameObject Player;
    public GameObject timerCanvas;




    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Type());
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueText.text == sentences[index])
        {
            continueButton.SetActive(true);
        }



       if(index > 2 && scoreText.text == "0")
        {
            dialogueCanvas.SetActive(false);

        }
       if(dialogueCanvas.activeInHierarchy == false)
        {
            sentenceOver = true;
        }
       if(scoreText.text == "100")
        {
            dialogueCanvas.SetActive(true);
          
            index = 3;
            timerCanvas.GetComponent<Timer>().enabled = false;

       
        }
        if (dialogueText.text == "")
        {
            dialogueCanvas.SetActive(false);

        }
        if(Timer.text == "0" && scoreText.text != "100")
        {
            failedText.SetActive(true);
            Player.GetComponent<Movement>().enabled = false;

        }
        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();

        }
        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene("Component");

        }
    }
    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

    }
    public void NextSentence()
    {
     
        continueButton.SetActive(false);
        if (index < sentences.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Type());
        }
        else
        {
            dialogueText.text = "";
            continueButton.SetActive(false);

        }


    }
}
