using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class AffectedBody : MonoBehaviour
{
    public GravityAffector gravityAffector;

    // Start is called before the first frame update
    void Start()
    {
        var rbody = GetComponent<Rigidbody>();
        rbody.constraints = RigidbodyConstraints.FreezeRotation;
        rbody.useGravity = false;

    }

    // Update is called once per frame
    void Update()
    {
        gravityAffector.Affect(transform);
    }
}
