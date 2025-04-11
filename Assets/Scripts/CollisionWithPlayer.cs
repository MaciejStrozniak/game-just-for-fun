using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWithPlayer : MonoBehaviour
{
    int countdownToExtinction = 0;
    private Player player;

    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.O)) 
        {
            if(player.isCausingDamage == false)
            {
                player.isCausingDamage = !player.isCausingDamage;
                Debug.Log(player.isCausingDamage);
            }
            else if(player.isCausingDamage == true)
            {
                player.isCausingDamage = !player.isCausingDamage;
                Debug.Log(player.isCausingDamage);
            }
        }       
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && player.isCausingDamage == false)
        {
            gameObject.GetComponent<SpriteRenderer>().color = UnityEngine.Random.ColorHSV();
            string enemyName = gameObject.GetComponent<ScriptableObjectEnemyTest>().scriptableObjectEnemy.MyString;
            Debug.Log(enemyName);
        }        
        else if(collision.gameObject.tag == "Player" && player.isCausingDamage == true)
        {
            gameObject.GetComponent<SpriteRenderer>().color = UnityEngine.Random.ColorHSV();
            countdownToExtinction ++;
            if(countdownToExtinction >= 3 && player.isCausingDamage)
                Destroy(gameObject);
        }
    }
}
