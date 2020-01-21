using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float offsetX;
    public float offsetY;
    public float offsetZ;
    public Transform player;

    void Update()
    {
        transform.position = new Vector3(player.transform.position.x + offsetX, player.transform.position.y + offsetY,transform.position.z + offsetZ);
    }
}
