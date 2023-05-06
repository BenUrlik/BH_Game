using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]public float maxPlayerHealth;
    [SerializeField]public float currentPlayerHealth;
    public GameObject player;
    public GameObject slider;

    // Start is called before the first frame update
    void Start() { currentPlayerHealth = maxPlayerHealth; }

    void Update() {
        slider.GetComponent<Slider>().value = currentPlayerHealth/maxPlayerHealth;
    }

    void OnParticleCollision(GameObject other)
    {
        // Debug.Log("Player has been hit!");
        // Debug.Log(playerHealth--);
        currentPlayerHealth--;
        if(currentPlayerHealth == 0) { 
            Destroy(player.GetComponent<SpriteRenderer>()); 
            Destroy(player.GetComponent<CircleCollider2D>());
        }
    }
}
