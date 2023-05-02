using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using BulletHellSpawning;

public class LazarEnemy : MonoBehaviour
{
    public BulletHellSpawning basicEnemy;
    public string attackPattern = "attackPattern1";

    void Start()
    {
        basicEnemy.SpawnPoint = (attackPattern == "attackPattern1") ? new Vector2(basicEnemy.boundaryX ,basicEnemy.boundaryY) : new Vector2(basicEnemy.boundaryX, basicEnemy.boundaryY);
        basicEnemy.Spawn(new Vector2(basicEnemy.SpawnPoint.x , basicEnemy.SpawnPoint.y));
    }

    void FixedUpdate()
    {
        switch (attackPattern) {
            case "attackPattern1" : attackPattern1(); break;
            case "attackPattern2" : attackPattern2(); break;
        }
    }

    void attackPattern1() {
        basicEnemy.verticalPingPong(basicEnemy.boundaryY * 2, "down");
    }

    void attackPattern2() {
        basicEnemy.verticalPingPong(basicEnemy.boundaryY * 2, "down");
    }
}
