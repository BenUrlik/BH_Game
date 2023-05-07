using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LancerEnemy : BulletHellSpawning
{
    public string attackPattern = "attack1";

    private void Start() {
        SpawnPoint = new Vector2(0,0);
        Spawn(new Vector2(SpawnPoint.x , SpawnPoint.y));
        Debug.Log(system);
        this.system = system;
    }

    private void FixedUpdate() {
        emit();
        switch (attackPattern) {
            case "attack1" : attack1(); break;
            case "attack2" : attack2(); break;
        }
    }

    public void attack1() { /* verticalPingPong(5, "right"); */ }
    public void attack2() { Debug.Log("attack 2"); }
}
