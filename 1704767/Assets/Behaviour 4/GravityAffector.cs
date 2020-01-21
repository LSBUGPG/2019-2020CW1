using UnityEngine;
using System.Collections;

public class GravityAffector : MonoBehaviour
{
    public float gravityStrength = -9.8f;
    public void Affect(Transform body)
    {
        Vector3 gravityVector = (body.position - transform.position).normalized;

        body.GetComponent<Rigidbody>().AddForce(gravityVector * gravityStrength);

        Quaternion targetRotation = Quaternion.FromToRotation(body.up, gravityVector) * body.rotation;
        body.rotation = Quaternion.Slerp(body.rotation, targetRotation, 50 * Time.deltaTime);
    }
}
