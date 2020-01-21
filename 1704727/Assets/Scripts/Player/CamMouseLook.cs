using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMouseLook : MonoBehaviour
{

    [SerializeField]
    Vector2 mouseLook;
    // Keeps track of how much movement the camera has made.

    Vector2 smoothV;
    // Required to make the mouseLook more smoothly. Not really necessary but it has been stated that without it is not smooth.

    public float sensitivity = 5f;
    // This is the sensitivity of the mouseLook.

    public float smoothing = 2f;
    // Smoothing the mouseLook.

    GameObject character;
    

    void Start()
    {
        character = this.transform.parent.gameObject;
        // Character is set to the parent that the object has this code, which is the Camera.
        // The character is the camera's parent.
    }

    // Update is called once per frame
    void Update()
    {
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        // md = Mouse Delta.

        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        // (x, y) axis due to 2 Vectors and not 3. The md is multiplied by the sensitivity and smoothing values.

        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
		// Lerp is a linear interpretation of a movement. Which won't instantly move a camera, it would move smoothly between two points which is the purpose of Lerp.
		// Lerp is used a lot on Character and NPC movement script.

		mouseLook += smoothV * Time.deltaTime;
		// mouseLook is adding the smoothV and applying it to the character.

		mouseLook.y = Mathf.Clamp(mouseLook.y, -80f, 80f);
		// The clamp is used to have limit to a certain rotation in this script.

		character.transform.rotation = Quaternion.AngleAxis(mouseLook.x, Vector3.up);

		transform.localRotation = Quaternion.AngleAxis(mouseLook.y, Vector3.left);
		//The "-mouseLook.y" is the inverted system to look up or look down script.

    }
}
