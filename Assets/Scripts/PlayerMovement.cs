using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float movementSpeed;

    [HideInInspector]
    public Vector2 moveDir;
    [HideInInspector]
    public Rigidbody2D rb;

    [HideInInspector]
    public bool isFacingLeft;
    [HideInInspector]
    public bool isFacingUp;

    public bool spawnFacingLeft;
    public bool spawnFacingUp;
    private Vector2 facingLeft;
    private Vector2 facingUp;
   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        facingLeft = new Vector2(-transform.localScale.x, transform.localScale.y);
        facingUp = new Vector2(transform.localScale.x, -transform.localScale.y);
        if (spawnFacingLeft)
        {
            transform.localScale = facingLeft;
            isFacingLeft = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        InputManagment();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void InputManagment()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDir = new Vector2(moveX, moveY).normalized;

        if (moveX > 0 && isFacingLeft)
        {
            isFacingLeft = false;
            FlipHorizontal();
        }
        if (moveX < 0 && !isFacingLeft)
        {
            isFacingLeft = true;
            FlipHorizontal();
        }
        if(moveY > 0 && isFacingUp)
        {
            isFacingUp = false;
            FlipVertical();
        }
        if(moveY < 0 && !isFacingUp)
        {
            isFacingUp = true;
            FlipVertical();
        }
    }

    private void Move()
    {
        rb.velocity = new Vector2(moveDir.x * movementSpeed, moveDir.y * movementSpeed);
    }

    public void FlipHorizontal()
    {
        if (isFacingLeft)
        {
            transform.localScale = facingLeft;
        }
        if (!isFacingLeft)
        {
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }

    public void FlipVertical()
    {
        if (isFacingUp)
        {
            transform.localScale = facingUp;
        }
        if (!isFacingUp)
        {
            transform.localScale = new Vector2(transform.localScale.x, -transform.localScale.y);
        }
    }
}
