using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // public attribute
    // private attribute
    [SerializeField] private float speed;
    [SerializeField] private float range;
    [SerializeField] private float expRange;
    [SerializeField] private GameObject expEffect;
    private Rigidbody2D bulletRb;
    private Vector2 firstPos;
    void Start()
    {
        bulletRb = GetComponent<Rigidbody2D>();
        bulletRb.velocity = transform.up * speed;
        firstPos = transform.position;
    }

    void Update()
    {
        Vector2 crtPos = transform.position;
        Vector2 distance = crtPos - firstPos;
        if (Mathf.Abs(distance.magnitude) > range)
        {
            DestroyBullet();
        }
    }
    void DestroyBullet()
    {
        GameObject effect = Instantiate(expEffect, transform.position, Quaternion.identity);
        effect.transform.localScale = Vector3.one * expRange;
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        DestroyBullet();
    }
}
