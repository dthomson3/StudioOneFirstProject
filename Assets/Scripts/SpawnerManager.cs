using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour {

    Camera cam;
    public float distanceFromCam;
    public Transform[] othersToSpawn;
    public Transform[] rocksToSpawn;
    public Transform[] holesToSpawn;
    public Transform otherOffset;
    public Transform autoScroll;

    void Start () {
        cam = Camera.main;
    }
	
	void Update () {
        
        
		foreach(Transform rock in rocksToSpawn)
        {
            //if a rock is gone, skips it
            if (rock == null)
            {
                continue;
            }
            //spawns the rocks in when they're almost in view of the camera
            float dist = rock.position.x - cam.transform.position.x;
            if (dist <= distanceFromCam && dist >= -distanceFromCam && rock.GetComponentInChildren<RockManager>() == null)
            {
                PoolingManager.instance.GetRock(rock);
            }
            //despawns rocks when they're out of view of the camera
            else if (dist <= -distanceFromCam && rock.GetComponentInChildren<RockManager>() != null)
            {
                rock.GetComponentInChildren<RockManager>().Despawn();
            }
        }

        //does the exact same as above but for otherHumans
        foreach(Transform other in othersToSpawn)
        {
            if (other == null)
            {
                continue;
            }

            float dist = other.position.x - cam.transform.position.x;
            if (dist <= distanceFromCam && dist >= -distanceFromCam && other.GetComponentInChildren<OtherManager>() == null)
            {
                PoolingManager.instance.GetOther(other);
            }
            else if (dist <= -distanceFromCam && other.GetComponentInChildren<OtherManager>() != null)
            {
                other.GetComponentInChildren<OtherManager>().Despawn();
            }
            //TODO Fix 
            //if (other.position.x <= otherOffset.position.x)
            //{
            //    other.parent = autoScroll;
            //}
        }
	}

    
}
