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

    public Sprite[] sprites;
    Animator anim;
    float autoScrollSpeed;
    bool hasFired;
    public float otherFireDelayMin;
    public float otherFireDelayMax;

    public void Initialize(int _currentStage)
    {
        //switches sprite based on the current stage
        switch (_currentStage)
        {
            case 1:   
                GetComponent<SpriteRenderer>().sprite = sprites[0];
                break;
            case 2:
                GetComponent<SpriteRenderer>().sprite = sprites[1];
                break;
            case 3:
                GetComponent<SpriteRenderer>().sprite = sprites[2];
                break;
        }
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
        autoScrollSpeed = AutoScrollManager.instance.autoScrollSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        //checks for collision against bullets, if there is a collision, it tells itself to die
        if (other.CompareTag(CherryManager.PLAYERBULLETTAG))
        {
            Die();
        }
    }

    void Die()
    {
        //destroys the parent object (the empty transform in the scene) then disables this object
        Score.instance.IncreaseScore();
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
        anim.SetBool("moving", true);
    }

    private void Update()
    {
        if (State == States.wander)
        {
            Scroll();
            StartCoroutine(Fire());
        }
    }

    IEnumerator Fire()
    {
        if (hasFired == false)
        {
            hasFired = true;
            PoolingManager.instance.GetCherry(transform.position, AutoScrollManager.instance.transform, CherryManager.OTHERTAG);
            yield return new WaitForSeconds(Random.Range(otherFireDelayMin, otherFireDelayMax));
            hasFired = false;
        }
    }

    void Scroll()
    {
        //constantly moves object and children 
        transform.parent.position += autoScrollSpeed * Vector3.right * Time.deltaTime;
    }
}
