using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotateSpeed;
    private Rigidbody2D playerRb;
    private Vector2 velocity;
    private float rotateAngle;
    public bool isMoving;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        velocity = transform.up * verticalInput * speed;
        rotateAngle = horizontalInput * rotateSpeed;
        isMoving = (horizontalInput != 0 || verticalInput != 0) ? true : false;

    }

    void FixedUpdate()
    {
        playerRb.MovePosition(playerRb.position + velocity * Time.fixedDeltaTime);
        playerRb.MoveRotation(playerRb.rotation - rotateAngle * Time.fixedDeltaTime);
    }

}
