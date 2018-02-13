using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryManager : MonoBehaviour {

    public bool isPlayerBullet;
    public float bulletSpeed;
    public float bulletLifeTime;
    public static string PLAYERTAG = "Player";
    public static string OTHERTAG = "Other";
    public static string PLAYERBULLETTAG = "PlayerBullet";
    public static string OTHERBULLETTAG = "OtherBullet";


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public void Initialize(string _itemName)
    {
        if (_itemName == PLAYERTAG)
        {
            transform.tag = PLAYERBULLETTAG;
        }
        else if(_itemName == OTHERTAG)
        {
            transform.tag = OTHERBULLETTAG;
        }
    }

    public void Move()
    {

    }

    public void DoDamage()
    {

    }
}
