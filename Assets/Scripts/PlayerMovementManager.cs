using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementManager : MonoBehaviour {

    public static PlayerMovementManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            DestroyImmediate(this);
            Debug.LogError("MULTIPLE PLAYERS IN SCENE: gameobject is " + gameObject.name);
        }
        else
        {
            instance = this;
        }
    }

    public float playerMoveSpeed;
    public float playerJumpSpeed;
    public float fallMultiplier;
    public bool hasJumped;
    Rigidbody rb;
    public Bounds AABBsize;
    Vector3 offset;

	void Start () {
        
        rb = GetComponent<Rigidbody>();
        //gets the initial offset for player vs cam
        offset = transform.parent.position - transform.position;
    }
    void Update () {
        //sets the bounds to the autoscroll GO with the original position kept in mind
        AABBsize.center = transform.parent.position - offset ;

        //moves/jumps
        Move();
        if (Input.GetAxis("Vertical") > 0)
        {
            Jump();
        }
        JumpPartTwo();
	}

    void Jump()
    {
        //starts jump, and disables the ability to jump in mid air
        if (hasJumped != true)
        {
            rb.velocity = Vector3.up * playerJumpSpeed;
            hasJumped = true;
        }
    }

    void JumpPartTwo()
    {
        //handles jump if the player is in midair, and falls nicely
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
    }

    void Move()
    {
        //moves player, so long as they're in the bounds
        float inputX = Input.GetAxis("Horizontal");
        transform.position += Vector3.right * inputX * Time.deltaTime * playerMoveSpeed;
        if (!AABBsize.Contains(transform.position))
        {
            transform.position -= Vector3.right * inputX * Time.deltaTime * playerMoveSpeed;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //enables jump on collision with floor
        if (collision.collider.CompareTag("Floor"))
        {
            hasJumped = false;
        }
    }
}
