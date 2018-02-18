using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingManager : MonoBehaviour {

#region singleton

    public static PoolingManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            DestroyImmediate(this);
            Debug.LogError("TWO PoolingManagerS IN SCENE. SECOND OBJECT: " + gameObject.name);
        }
        else
        {
            instance = this;
        }
    }
#endregion

    public HashSet<GameObject> pooledCherries = new HashSet<GameObject>();
    public HashSet<GameObject> pooledOtherSprites = new HashSet<GameObject>();
    public HashSet<GameObject> pooledRocks = new HashSet<GameObject>();

    public GameObject cherryPrefab;
    public GameObject otherSpritePrefab;
    public GameObject rockPrefab;

    public float cherriesToPool;
    public float otherSpritesToPool;
    public float rocksToPool = 5;


    void Start()
    {
        //creates the set amount of cherries to be used in pooling
        for (int index = 0; index < cherriesToPool; index++)
        {
            GameObject cherry = Instantiate(cherryPrefab);
            pooledCherries.Add(cherry);
            cherry.gameObject.SetActive(false);
            print("cherry made");

        }
        //creates the set amount of OtherHumans to be used in pooling
        for (int secondIndex = 0; secondIndex < otherSpritesToPool; secondIndex++)
        {
            GameObject other = Instantiate(otherSpritePrefab);
            pooledOtherSprites.Add(other);
            other.gameObject.SetActive(false);
            print("Other human made");
        }
        //creates the set amount of Rocks to be used in pooling
        for (int thirdIndex = 0; thirdIndex < rocksToPool; thirdIndex++)
        {
            GameObject rock = Instantiate(rockPrefab);
            pooledRocks.Add(rock);
            rock.gameObject.SetActive(false);
            print("ROCK MADE");
        }
    }

    public void GetCherry(Vector3 _pos, Transform _parent, string itemName)
    {
        //checks for a cherry that's free
        foreach (GameObject cherry in pooledCherries)
        {
            //if cherry isn't free, goes to next cherry
            if (cherry.activeInHierarchy == true)
                continue;
            //otherwise, sets the parent and position, sets object to active and Initializes it
            cherry.transform.parent = _parent;
            cherry.transform.position = _pos;
            cherry.SetActive(true);
            cherry.GetComponent<CherryManager>().Initialize(itemName);
            break;
        }
    }

    public void GetRock(Transform _parent)
    {
        //does the same as what the cherry does, but based only on the parent object
        foreach (GameObject rock in pooledRocks)
        {
            if (rock.activeInHierarchy == true)
                continue;
            rock.transform.position = _parent.position;
            rock.transform.parent = _parent;
            rock.SetActive(true);
            rock.GetComponent<RockManager>().Initialize(GameManager.instance.currentStage);
            break;
        }
    }

    public void GetOther(Transform _parent)
    {
        //does the same as rock
        foreach (GameObject other in pooledOtherSprites)
        {
            if (other.activeInHierarchy == true)
                continue;
            other.transform.position = _parent.position;
            other.transform.parent = _parent;
            other.SetActive(true);
            other.GetComponent<Other>().Initialize(GameManager.instance.currentStage);
            break;
        }
    }
}
