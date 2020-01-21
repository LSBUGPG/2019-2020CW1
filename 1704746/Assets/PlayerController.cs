using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    private float speed;
    private float runSpeed = 10f;
    private float walkSpeed = 5f;
    

    private Vector3 velocity = Vector3.zero;
    private Rigidbody rb;

    public Camera cam;
    public float lookSensitivity = 3f;

    private Vector3 rotation = Vector3.zero;
    private Vector3 cameraRotation = Vector3.zero;

    private float score;

    public Text txt;

    public GameObject collectable;
    public GameObject firePoint;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = walkSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        float xMove = Input.GetAxisRaw("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical");

        float yRot = Input.GetAxisRaw("Mouse X");
        float xRot = Input.GetAxisRaw("Mouse Y");

        Vector3 moveHori = transform.right * xMove;
        Vector3 moveVerti = transform.forward * zMove;

        Vector3 velocity = (moveHori + moveVerti).normalized * speed;

        Vector3 _rotation = new Vector3(0f, yRot, 0f) * lookSensitivity;
        Vector3 _cameraRotation = new Vector3(xRot, 0f, 0f) * lookSensitivity;

        rotation = _rotation;
        cameraRotation = _cameraRotation;

        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = runSpeed;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = walkSpeed;
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (score <= 1)
            {
                Instantiate(collectable, firePoint.transform.position, firePoint.transform.rotation);
                score -= 1;
            }
        }
        PerformRotation();


        txt.text = "Score:" + score;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Collectable")
        {
            score += 1;
            Destroy(collision.gameObject);

        }
    }

    void PerformRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));

        if (cam != null)
        {
            cam.transform.Rotate(-cameraRotation);
        }

    }
}
