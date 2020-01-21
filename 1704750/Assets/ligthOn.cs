using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ligthOn : MonoBehaviour
{
    public Light lgt;
    public float area;
    private const float coef = 10.2f;
    public float intensity;
    private bool lightOn;

    // Start is called before the first frame update
    void Start()
    {
        lgt = GetComponent<Light>();
        lightOn = false;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && lightOn == false)
        {
            area = 100;
            lightOn = true;
            Invoke("lightOff", 5f);
        }
    }
    void lightOff()
    {
        lightOn = false;
    }


    // Update is called once per frame
    void Update()
    {
        area -= coef * Time.deltaTime;
        lgt.intensity = area;

    }
}
