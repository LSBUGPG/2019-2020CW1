using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PlayerLocomotion : MonoBehaviour
{
    public float speed = 15;
    // Update is called once per frame
    void FixedUpdate()
    {
        var direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        var rBody = GetComponent<Rigidbody>();
        rBody.MovePosition(rBody.position + transform.TransformDirection(direction * speed * Time.fixedDeltaTime));
    }
}
