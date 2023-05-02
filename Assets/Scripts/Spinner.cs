using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    public BulletHellSpawning basicEnemy;
    public string attackPattern = "attackPattern1";

    void Start()
    {
        basicEnemy.SpawnPoint = new Vector2(-basicEnemy.boundaryX, basicEnemy.boundaryY - 1);
        basicEnemy.Spawn(new Vector2(basicEnemy.SpawnPoint.x , basicEnemy.SpawnPoint.y));
    }

    void FixedUpdate()
    {
        switch (attackPattern) {
            case "attackPattern1" : attackPattern1(); break;
            case "attackPattern2" : attackPattern2(); break;
        }
        basicEnemy.rotationalMovement();
    }

    void attackPattern1() { basicEnemy.horizontalPingPong(basicEnemy.boundaryX, "right"); }

    void attackPattern2() { basicEnemy.horizontalPingPong(basicEnemy.boundaryX * 2, "left"); }
}
