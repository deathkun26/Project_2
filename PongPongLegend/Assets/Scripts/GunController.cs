using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GunType
{
    Rocket, TripleGun, DoubleGun, SingleGun
}
public class GunController : MonoBehaviour
{
    // public attribute
    public GunType gunType;
    public GameObject bulletPrefab;
    public List<Transform> shootPoints;
    public Camera mainCamera;

    // private attribute
    private Vector2 followPoint;
    private Vector2 lookVector;
    private Animator gunAn;

    void Start()
    {
        gunAn = GetComponent<Animator>();
    }

    void Update()
    {
        followPoint = Input.mousePosition;
    }

    void FixedUpdate()
    {
        lookVector = mainCamera.ScreenToWorldPoint(followPoint) - transform.position;
        float angle = Mathf.Atan2(lookVector.y, lookVector.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
