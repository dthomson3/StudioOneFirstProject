using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementManager : MonoBehaviour {

    public float playerMoveSpeed;
    public float playerJumpSpeed;
    public float fallMultiplier;
    Rigidbody2D rb;
    public Bounds AABBsize;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        
    }
	
	// Update is called once per frame
	void Update () {
        

        Move();
        if (Input.GetButtonDown("Jump"))
            Jump();
        JumpPartTwo();
	}

    void Jump()
    {
        rb.velocity = Vector2.up * playerJumpSpeed;
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
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(AABBsize.center, AABBsize.size);
    }
}
