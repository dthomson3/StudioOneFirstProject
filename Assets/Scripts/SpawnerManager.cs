using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour {

    Camera cam;
    public float distanceFromCam;
    public Transform[] othersToSpawn;
    public Transform[] rocksToSpawn;
    public Transform[] holesToSpawn;

    // Use this for initialization
    void Start () {
        cam = Camera.main;
    }
	
	// Update is called once per frame
	void Update () {
		foreach(Transform rock in rocksToSpawn)
        {
            float dist = rock.position.x - cam.transform.position.x;
            if (dist <= distanceFromCam && dist >= -distanceFromCam && rock.GetComponentInChildren<RockManager>() == null)
            {
                print("AAAAAAAA");
                PoolingManager.instance.GetRock(rock);
            }
            else if (dist <= -distanceFromCam && rock.GetComponentInChildren<RockManager>() != null)
            {
                print("EEEEEEEEEEE");
                rock.GetComponentInChildren<RockManager>().Despawn();
            }
            else
            {
                print("WWWWWWWWWWWWWW");
            }
        }
	}

    
}
