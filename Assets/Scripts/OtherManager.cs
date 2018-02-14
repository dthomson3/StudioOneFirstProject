using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Initialize(int _currentStage)
    {
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

    private void OnCollisionEnter(Collision collision)
    {
        print("ded");
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
        //die animation etx
        Despawn();
        GameObject parent = transform.parent.gameObject;
        transform.parent = null;
        Destroy(parent);
        print("3");


    }

    public void Despawn()
    {
        print("DEDEDEED");
        gameObject.SetActive(false);
    }
}
