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
    private bool isDestroy;
    void Start()
    {
        bulletRb = GetComponent<Rigidbody2D>();
        bulletRb.velocity = transform.up * speed;
        firstPos = transform.position;
        isDestroy = false;
    }

    void Update()
    {
        Vector2 crtPos = transform.position;
        Vector2 distance = crtPos - firstPos;
        if (Mathf.Abs(distance.magnitude) > range && !isDestroy)
        {
            DestroyBullet();
        }
    }
    void DestroyBullet()
    {
        isDestroy = true;
        GameObject effect = Instantiate(expEffect, transform.position, Quaternion.identity);
        Transform[] effectChild = effect.GetComponentsInChildren<Transform>();
        foreach (Transform child in effectChild)
        {
            child.transform.localScale *= expRange;
        }
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isDestroy && other.tag != gameObject.tag)
        {
            DestroyBullet();
        }
    }
}
