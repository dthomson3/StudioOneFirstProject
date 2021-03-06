﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour {

    public void Die()
    {
        print("PLAYER DIED");
        SceneManager.LoadScene(0);
    }

    private void OnTriggerEnter(Collider other)
    {
        print("COLLIDED WITH" + other.name);
        if (other.CompareTag("Rock") || other.CompareTag(CherryManager.OTHERBULLETTAG))
        {
            Die();
        }
    }

    // Use this for initialization
    void Start () {
        Score.instance.ResetScore();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
