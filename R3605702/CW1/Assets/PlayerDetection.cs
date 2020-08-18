using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    #region Singleton

    public static PlayerDetection instance;

    void Awake()
    {
        instance = this;

    }

    #endregion

    public GameObject player;
}
