using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpottingManager : MonoBehaviour
{

    public LayerMask layerMask;

    public GameObject pinPrefab;

    public Transform canvas;

    List<Transform> pins;

    void Start()
    {
        pins = new List<Transform>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, Mathf.Infinity, layerMask))
            {
                if (!pins.Contains(hit.transform)){
                    var go = Instantiate(pinPrefab, canvas);
                    go.GetComponent<PinUI>().target = hit.transform;
                    pins.Add(hit.transform);
                }
            }
        }

    }
}
