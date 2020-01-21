using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceUI : MonoBehaviour
{
    public Transform position1;
    public Transform position2;
    public int decimalPlaces;
    Text textComponent;

    void Start()
    {
        textComponent = GetComponent<Text>();
        textComponent.alignment = TextAnchor.MiddleRight;
    }

    void Update()
    {
        textComponent.text = System.Math.Round(Vector3.Distance(position1.position, position2.position), decimalPlaces).ToString() + "m";
    }

}
