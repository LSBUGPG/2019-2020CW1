using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class ExplosionTrigger : MonoBehaviour
{
    public ParticleSystem explosion;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            explosion.Play();
            CameraShaker.Instance.ShakeOnce(4f, 4f, 1f, 1f);
        }
    }
}