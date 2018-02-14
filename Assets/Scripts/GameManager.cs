using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    void Awake()
    {
        if (instance != null)
        {
            DestroyImmediate(this);
            Debug.LogError("Multiple GameManagers in scene. second Game object is :" + gameObject.name);
        }
        else
        {
            instance = this;
        }

    }

    public int currentStage;
    // Use this for initialization
    void Start()
    {
        currentStage = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
