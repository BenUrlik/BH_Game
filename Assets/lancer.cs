using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lancer : MonoBehaviour
{
    public string attackPattern = "attack1";
    public int enemyHealth = 5;

    private void Start() {
        
    }

    private void FixedUpdate() {
        emit();
        switch (attackPattern) {
            case "attack1" : attack1(); break;
            case "attack2" : attack2(); break;
        }
    }

    public void attack1() { verticalPingPong(5, "right");  }
    public void attack2() { horizontalPingPong(5, "down"); }
}
