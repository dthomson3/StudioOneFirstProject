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
                PoolingManager.instance.GetRock(rock);
            }
            else if (dist <= -distanceFromCam && rock.GetComponentInChildren<RockManager>() != null)
            {
                rock.GetComponentInChildren<RockManager>().Despawn();
            }
        }
        foreach(Transform other in othersToSpawn)
        {
            float dist = other.position.x - cam.transform.position.x;
            if (dist <= distanceFromCam && dist >= -distanceFromCam && other.GetComponentInChildren<OtherManager>() == null)
            {
                PoolingManager.instance.GetOther(other);
            }
            else if (dist <= -distanceFromCam && other.GetComponentInChildren<OtherManager>() != null)
            {
                other.GetComponentInChildren<OtherManager>().Despawn();
            }
        }
	}

    
}
