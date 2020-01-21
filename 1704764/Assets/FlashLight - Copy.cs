using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

	public GameObject flashLightLight;

	private void Update()
	{

		if(Input.GetKeyDown(KeyCode.Mouse1)) {
			flashLightLight.SetActive(!flashLightLight.activeSelf);
		}

	}
}