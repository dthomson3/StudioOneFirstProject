using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryManager : MonoBehaviour {

    public bool isPlayerBullet;
    public float bulletSpeed;
    public float bulletLifeTime;
    public Vector3 moveDirection;
    public static string PLAYERTAG = "Player";
    public static string OTHERTAG = "Other";
    public static string PLAYERBULLETTAG = "PlayerBullet";
    public static string OTHERBULLETTAG = "OtherBullet";
    public static string PLAYERBULLETLAYER = "PlayerBullet";
    public static string OTHERBULLETLAYER = "OtherBullet";


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}
    
    public void Initialize(string _itemName)
    {
        if (_itemName == PLAYERTAG)
        {
            transform.tag = PLAYERBULLETTAG;
            gameObject.layer = LayerMask.NameToLayer(PLAYERBULLETLAYER);
            moveDirection = Vector3.forward;
            isPlayerBullet = true;
            
        }
        else if(_itemName == OTHERTAG)
        {
            transform.tag = OTHERBULLETTAG;
            gameObject.layer = LayerMask.NameToLayer(OTHERBULLETLAYER);
            moveDirection = Vector3.back;
            isPlayerBullet = false;
        }
        StartCoroutine(Despawn());
    }

    public void Move()
    {
        transform.position += bulletSpeed * moveDirection * Time.deltaTime;
    }

    public void DoDamage()
    {

    }

    public IEnumerator Despawn()
    {
        yield return new WaitForSeconds(bulletLifeTime);
        gameObject.SetActive(false);
    }
}
