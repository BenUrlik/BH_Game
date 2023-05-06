using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
using UnityEngine.InputSystem;

public class TestScript : MonoBehaviour
{
    public NPCConversation myConversation;
    public InputAction click;
    public InputAction progress;
    
    private void OnEnable()
    {
        click.Enable();
    }
    private void OnDisable()
    {
        click.Disable();
    }

    private void Update()
    {
        if(click.triggered)
        {
            ConversationManager.Instance.StartConversation(myConversation);
        }
        else if(ConversationManager.Instance.IsConversationActive && progress.triggered)
        {
            ConversationManager.Instance.SelectNextOption();
        }
            
        
    }
}
