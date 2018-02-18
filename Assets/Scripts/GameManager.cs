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

#region events
    private void OnEnable()
    {
        GlobalEventManager.ChangeStage.AddListener(ChangeStage);
    }

    private void OnDisable()
    {
        GlobalEventManager.ChangeStage.RemoveListener(ChangeStage);
    }
#endregion

    void Update()
    {

    }

    void ChangeStage(ChangeStage stage)
    {
        print("STAGE CHANGED GAME MANAGER");
        if (currentStage > 3)
        {
            currentStage++;
        }
    }
}
