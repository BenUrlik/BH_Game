using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] public float maxPlayerHealth;
    [SerializeField] public float currentPlayerHealth;
    [SerializeField] public float invulnFlashDelay = 0.1f;
    [SerializeField] public float invulnTime = 1f;
    public GameObject player;
    public GameObject slider;
    private bool invincible = false;

    // Start is called before the first frame update
    void Start() { currentPlayerHealth = maxPlayerHealth; }

    void Update()
    {
        slider.GetComponent<Slider>().value = currentPlayerHealth / maxPlayerHealth;
    }

    void OnParticleCollision(GameObject other)
    {
        if (other.name != "PlayerBulletSpawner")
        {
            HandleHurt();
        }
        if (currentPlayerHealth == 0)
        {
            HandleDeath();
        }

    }

    void HandleHurt()
    {
        if (invincible)
        {
            return;
        }
        currentPlayerHealth--;
        invincible = true;
        StartCoroutine(TempInvulnerability());
    }

    public IEnumerator TempInvulnerability()
    {
        invincible = true;
        float time = 0.0f;
        while (time < invulnTime)
        {
            player.GetComponent<SpriteRenderer>().enabled = !player.GetComponent<SpriteRenderer>().enabled;
            yield return new WaitForSeconds(invulnFlashDelay);
            time += invulnFlashDelay;
        }
        player.GetComponent<SpriteRenderer>().enabled = true;
        invincible = false;
    }

    void HandleDeath()
    {
        Destroy(player.GetComponent<SpriteRenderer>());
        Destroy(player.GetComponent<CircleCollider2D>());
    }
}
