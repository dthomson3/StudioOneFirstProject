using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockManager : MonoBehaviour {

    public Sprite[] sprites;
    public Vector3 rayOrigin;
    public float checkRaycastLength;

    void Start () {
		
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
        //checks if the player has jumped over the edge
        RaycastHit hit;
        if (Physics.Raycast(rayOrigin,transform.up, out hit, checkRaycastLength))
        {
            print("hot");
            if (hit.transform.CompareTag(CherryManager.PLAYERTAG))
            {
                print("Cleared Jump!");
            }
        }
    }
}
