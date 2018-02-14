using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //creates singleton
#region singleton
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
    #endregion

    public int currentStage;
    void Start()
    {
        currentStage = 1;
    }

    void Update()
    {

    }
}
