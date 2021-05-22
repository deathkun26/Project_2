using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // public attribute
    public float speed;
    public float range;
    // private attribute
    private Rigidbody2D bulletRb;
    void Start()
    {
        bulletRb = GetComponent<Rigidbody2D>();
        bulletRb.velocity = transform.up * speed;
    }

    void Update()
    {

    }
}
