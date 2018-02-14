using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFiringManager : MonoBehaviour {

    public Transform firingPosition;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Jump"))
        {
            print("Fire");
            PoolingManager.instance.GetCherry(firingPosition.position, transform, CherryManager.PLAYERTAG);
        }
        
	}
}
