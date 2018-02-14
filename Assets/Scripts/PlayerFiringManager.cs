using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFiringManager : MonoBehaviour {

    public Transform firingPosition;
    public Transform parent;

	void Update () {
		if (Input.GetButtonDown("Jump"))
        {
            print("Fire");
            //spawns cherry at given location and says player fired
            PoolingManager.instance.GetCherry(firingPosition.position, parent, CherryManager.PLAYERTAG);
        }
        
	}
}
