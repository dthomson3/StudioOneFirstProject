﻿using System.Collections;
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

    public GameObject cherryPrefab;
    public GameObject otherSpritePrefab;

    public float cherriesToPool;
    public float otherSpritesToPool;



    // Use this for initialization
    void Start() {
        for (int index = 0; index < cherriesToPool; index++)
        {
            GameObject cherry = Instantiate(cherryPrefab);
            pooledCherries.Add(cherry);
            cherry.gameObject.SetActive(false);
        }
        for (int secondIndex = 0; secondIndex < otherSpritesToPool; secondIndex++)
        {
            GameObject other = Instantiate(otherSpritePrefab);
            pooledOtherSprites.Add(other);
            other.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.K))
        {
            GetCherry(new Vector3(Random.Range(-100, 100), Random.Range(-100, 100), Random.Range(-100, 100)), null, CherryManager.OTHERTAG);
        }
    }

    public void GetCherry(Vector3 _pos, Transform _parent, string itemName)
    {

        foreach (GameObject cherry in pooledCherries)
        {
            if (cherry.activeInHierarchy == true)
                continue;
            cherry.transform.parent = _parent;
            cherry.transform.position = _pos;
            cherry.SetActive(true);
            cherry.GetComponent<CherryManager>().Initialize(itemName);
            break;
        }
        
    }
}
