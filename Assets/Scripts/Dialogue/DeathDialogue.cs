using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class DeathDialogue : MonoBehaviour
{
    public NPCConversation myConversation;
    public GameObject player;
    public float playerHealth;
    public int deathCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = player.GetComponent<Player>().currentPlayerHealth;
    }

    // Update is called once per frame
    void Update()
    {
        playerHealth = player.GetComponent<Player>().currentPlayerHealth;
        Debug.Log(playerHealth);
       if( !(ConversationManager.Instance.IsConversationActive) && deathCount == 0 && playerHealth == 0.0)
        {
            ConversationManager.Instance.StartConversation(myConversation);
            deathCount++;
        }
    }
}
