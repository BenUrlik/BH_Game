using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazarEnemy : BulletHellSpawning
{
    public string attackPattern = "attack1";

    private void Start() {
        SpawnPoint = new Vector2(0,0);
        Spawn(new Vector2(SpawnPoint.x , SpawnPoint.y));
    }

    private void FixedUpdate() {
        emit();
        // switch (attackPattern) {
        //     case "attack1" : attack1(); break;
        //     case "attack2" : attack2(); break;
        // }
    }

    public void attack1() { Debug.Log("attack 1"); }
    public void attack2() { Debug.Log("attack 2"); }
}
