using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoScrollManager : MonoBehaviour {

#region singleton
    public static AutoScrollManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            DestroyImmediate(this);
            Debug.LogError("TWO INSTANCES IN SCENE. Game Object of second instance: " + gameObject.name);
        }
        else
        {
            instance = this;
        }
    }
    #endregion

    public float autoScrollSpeed;
    public bool isPlayerAlive;

    public void Update()
    {
        Scroll();
    }

    void Scroll()
    {
        transform.position += autoScrollSpeed * Vector3.right * Time.deltaTime;
    }
}
