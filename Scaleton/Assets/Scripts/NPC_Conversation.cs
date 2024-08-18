using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
public class NPC_Conversation : MonoBehaviour
{
    public NPCConversation dialogue;
    [SerializeField] bool destroyAfterLeave;
    [SerializeField] bool startNPC;
    bool inReach;
    bool becameVisible;

    [SerializeField] GameObject canvas;

    private void Awake()
    {
        dialogue = GetComponent<NPCConversation>();
    }
    private void Start()
    {
        canvas.SetActive(false);
        if(startNPC)
        ConversationManager.Instance.StartConversation(dialogue);
    }

    private void Update()
    {
        if(!startNPC && inReach && Input.GetKeyDown(KeyCode.E))
        {
            ConversationManager.Instance.StartConversation(dialogue);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!startNPC)
        {
            if (collision.tag == "Player") canvas.SetActive(true);
            inReach = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!startNPC)
        {
            if (collision.tag == "Player") canvas.SetActive(false);
            inReach = false;
        }
            
    }

    private void OnBecameVisible()
    {
        becameVisible = true;
    }


    private void OnBecameInvisible()
    {
        if (destroyAfterLeave && becameVisible) gameObject.SetActive(false);
    }
}
