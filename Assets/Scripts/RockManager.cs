using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockManager : MonoBehaviour {

    public Sprite stageOneSprite;
    public Sprite stageTwoSprite;
    public Sprite stageThreeSprite;

    void Start () {
		
	}

	void Update () {
		
	}

    public void Initialize(int _currentStage)
    {
        //changes sprite based off currentStage
        print("Initialized");
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

    public void Despawn()
    {
        //disables object to be pooled again
        gameObject.SetActive(false);
    }
}
