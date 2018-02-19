using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockManager : MonoBehaviour {

    public Sprite[] sprites;
    public float distanceToSpriteEdge;
    bool scored = false;

    void Start () {
        scored = false;
	}

	void Update () {
        CheckForPlayer();
	}

    public void Initialize(int _currentStage)
    {
        //changes sprite based off currentStage
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

    public void Despawn()
    {
        //disables object to be pooled again
        gameObject.SetActive(false);
    }

    void CheckForPlayer()
    {
        if (scored == false && PlayerMovementManager.instance.transform.position.x > transform.position.x + distanceToSpriteEdge)
        {
            print("add score");
            scored = true;
        }
    }
}
