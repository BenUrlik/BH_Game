using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static int playerHealth;
    public GameObject player;

    // Start is called before the first frame update
    void Start() { playerHealth = 3; }

    void Update() { }

    void OnParticleCollision(GameObject other)
    {
        Debug.Log("Player has been hit!");
        Debug.Log(playerHealth--);
        if(playerHealth == 0) { 
            Destroy(player.GetComponent<SpriteRenderer>()); 
            Destroy(player.GetComponent<CircleCollider2D>());
        }
    }
}
