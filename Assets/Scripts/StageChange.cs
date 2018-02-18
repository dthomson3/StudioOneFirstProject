using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageChange : MonoBehaviour {
    public float visibleDistance;
    public int currentStage = 1;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        CheckDistance();
	}

    void CheckDistance()
    {
        float dist = transform.position.x - Camera.main.transform.position.x;
        if (dist > visibleDistance)
        {
            var data = new ChangeStage();
            GlobalEventManager.ChangeStage.Invoke(data);
            Destroy(gameObject);
        }
    }
}
