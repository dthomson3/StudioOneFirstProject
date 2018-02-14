using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementManager : MonoBehaviour {

    public float playerMoveSpeed;
    public float playerJumpSpeed;
    public float fallMultiplier;
    public bool hasJumped;
    Rigidbody2D rb;
    public Bounds AABBsize;
    Vector3 offset;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        offset = transform.parent.position - transform.position;
    }

    // Update is called once per frame
    void Update () {
        AABBsize.center = transform.parent.position - offset ;

        Move();
        if (Input.GetAxis("Vertical") > 0)
        {
            Jump();
        }
        JumpPartTwo();
	}

    void Jump()
    {
        if (hasJumped != true)
        {
            rb.velocity = Vector2.up * playerJumpSpeed;
            hasJumped = true;
        }
    }

    void JumpPartTwo()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
    }

    void Move()
    {
        float inputX = Input.GetAxis("Horizontal");
        transform.position += Vector3.right * inputX * Time.deltaTime * playerMoveSpeed;
        if (!AABBsize.Contains(transform.position))
        {
        transform.position -= Vector3.right * inputX * Time.deltaTime * playerMoveSpeed;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Floor"))
        {
            hasJumped = false;
        }
    }
}
