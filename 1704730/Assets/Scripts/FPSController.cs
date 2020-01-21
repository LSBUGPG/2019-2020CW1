using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{

    public float speed = 2f;
    public float sensitivity = 2f;

    CharacterController player;
    public GameObject eyes;

    float moveLR;
    float moveFB;
    float rotX;
    float rotY;

    // Start is called before the first frame update
    void Start()
    {

        player = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {

        moveLR = Input.GetAxis("Horizontal") * speed;
        moveFB = Input.GetAxis("Vertical") * speed;

        rotX = Input.GetAxis("Mouse X") * sensitivity;
        rotY = Input.GetAxis("Mouse Y") * sensitivity;

        Vector3 movement = new Vector3(moveLR, 0, moveFB);
        transform.Rotate(0, rotX, 0);

        movement = transform.rotation * movement;
        player.Move(movement * Time.deltaTime);

        eyes.transform.Rotate(-rotY, 0, 0);

    }
}
