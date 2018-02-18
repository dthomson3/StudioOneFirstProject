using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryManager : MonoBehaviour
{

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


    void Update()
    {
        Move();
    }

    public void Initialize(string _itemName)
    {
        //Initializes object based off whether player or enemy shot
        if (_itemName == PLAYERTAG)
        {
            //player shot, sets tag, layer and movedir accordingly
            transform.tag = PLAYERBULLETTAG;
            gameObject.layer = LayerMask.NameToLayer(PLAYERBULLETLAYER);
            moveDirection = Vector3.forward;
            isPlayerBullet = true;

        }
        else if (_itemName == OTHERTAG)
        {
            //OtherHuman shot, sets tag, layer and movedir accordingly
            transform.tag = OTHERBULLETTAG;
            gameObject.layer = LayerMask.NameToLayer(OTHERBULLETLAYER);
            moveDirection = Vector3.back;
            isPlayerBullet = false;
        }
        //starts the countdown to despawn the object
        StartCoroutine(Despawn());
    }

    public void Move()
    {
        //moves in the fired direction
        transform.position += bulletSpeed * moveDirection * Time.deltaTime;
    }

    public void DoDamage()
    {

    }

    public IEnumerator Despawn()
    {
        //disables object after delay to be pooled again
        yield return new WaitForSeconds(bulletLifeTime);
        gameObject.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        //checks for collision against bullets, if there is a collision, it tells itself to die
        print("COLLIDED WITH: " + gameObject.name);
    }
}
