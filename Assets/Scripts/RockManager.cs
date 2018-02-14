using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockManager : MonoBehaviour {

    public Sprite stageOneSprite;
    public Sprite stageTwoSprite;
    public Sprite stageThreeSprite;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Initialize(int _currentStage)
    {
        print("ecks de");
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

        gameObject.SetActive(false);
    }
}
