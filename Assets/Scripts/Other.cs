using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Other : MonoBehaviour
{
    public enum States
    {
        idle,
        wander
    }

    public States State;

    Animator anim;
    public bool doScroll = false;
    float autoScrollSpeed;

    public void Initialize(int _currentStage)
    {
        //switches sprite based on the current stage
        print("initialized Other");
        switch (_currentStage)
        {
            case 1:
                print("stage 1");
                break;
            case 2:
                print("stage 2");
                break;
            case 3:
                print("stage 3");
                break;
        }
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
        autoScrollSpeed = AutoScrollManager.instance.autoScrollSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //checks for collision against bullets, if there is a collision, it tells itself to die
        print("COLLIDED WITH: " + gameObject.name);
        if (collision.transform.CompareTag("PlayerBullet"))
        {
            print("lele");
        }
        if (collision.collider.CompareTag(CherryManager.PLAYERBULLETTAG))
        {
            print("ye");
            Die();
        }
    }

    void Die()
    {
        //destroys the parent object (the empty transform in the scene) then disables this object
        Despawn();
        GameObject parent = transform.parent.gameObject;
        transform.parent = null;
        Destroy(parent);
    }

    public void Despawn()
    {
        //disables object to be pooled again
        print("DESPAWNED");
        gameObject.SetActive(false);
    }

    public void Animate()
    {
        doScroll = true;
        anim.SetBool("moving", true);
    }

    private void Update()
    {
        if (doScroll == true)
        {
            Scroll();
        }
    }

    void Scroll()
    {
        //constantly moves object and children 
        transform.parent.position += autoScrollSpeed * Vector3.right * Time.deltaTime;
    }
}
