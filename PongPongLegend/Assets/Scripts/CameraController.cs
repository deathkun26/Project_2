using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    void Start()
    {
        offset.z = -10;
    }

    void FixedUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
