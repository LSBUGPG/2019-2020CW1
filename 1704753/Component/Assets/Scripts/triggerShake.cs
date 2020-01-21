using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerShake : MonoBehaviour
{
    public CameraShake shaker;

    public void ShakeCamera() {
        StartCoroutine(shaker.Shake(0.15f, 1.0f));
    }

}
