using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isMoving;
    [SerializeField] private float speed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private int health;
    private Rigidbody2D playerRb;
    private Vector2 move;
    private float angle;

    void Start()
    {

        playerRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        isMoving = (horizontalInput != 0 || verticalInput != 0) ? true : false;
        move.x = horizontalInput;
        move.y = verticalInput;
        playerRb.velocity = move * speed;
    }

    void FixedUpdate()
    {
        if (move != Vector2.zero)
        {
            angle = Mathf.Atan2(move.y, move.x) * Mathf.Rad2Deg - 90f;
        }
        transform.rotation = Quaternion.RotateTowards(transform.rotation,
        Quaternion.Euler(0, 0, angle), rotateSpeed * Time.fixedDeltaTime);
    }

    public void TakeHit(float damage)
    {
        Debug.Log("Player take hit !!");
    }
}
