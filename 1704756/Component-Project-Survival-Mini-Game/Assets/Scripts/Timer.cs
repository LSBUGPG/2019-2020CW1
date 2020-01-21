using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{

    public TextMeshPro timer;
    public float timeLeft = 60f;

    void Start()
    {
        
    }

    void Update()
    {
        timer.text = timeLeft.ToString("F0");
        timeLeft -= Time.deltaTime;
    }
}
