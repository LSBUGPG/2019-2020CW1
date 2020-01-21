using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinUI : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    void LateUpdate()
    {
        if (target == null)
        {
            Destroy(gameObject);
        }
        else
        {
            var worldToScreenPoint = Camera.main.WorldToScreenPoint(target.position + offset);
            transform.position = worldToScreenPoint;
            GetComponent<Image>().enabled = worldToScreenPoint.z > 0;
        }
    }
}
