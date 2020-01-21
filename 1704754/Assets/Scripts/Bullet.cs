using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float life;
    

    private void Start()
    {
        Invoke("DestroyProjectile", life);
    }

    private void Update()
    {
        transform.Translate(transform.up * speed * Time.deltaTime);
    }

}
