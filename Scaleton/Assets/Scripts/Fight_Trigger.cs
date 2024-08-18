using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
public class Fight_Trigger : MonoBehaviour
{
    [SerializeField] Animator cam;
    [SerializeField] GameObject barrier;
    [SerializeField] GameObject bossCanvas;
    [SerializeField] GameObject boss;
    NPCConversation dialogue;
    private void Start()
    {
        dialogue = GetComponent<NPCConversation>();
        bossCanvas.SetActive(false);
        cam.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player") return;
        StartFight();
        ConversationManager.Instance.StartConversation(dialogue);
        barrier.SetActive(true);
        GetComponent<BoxCollider2D>().enabled = false;
    }
    void StartFight()
    {
        cam.enabled = true;
        cam.Play("CameraMove");
    }

    public void StartBattle()
    {
        bossCanvas.SetActive(true);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Shoot>().enabled = true;
        Invoke("ActivateAI", 1.8f);
    }

    void ActivateAI()
    {
        boss.GetComponent<Boss_Battle>().StartAttack();
    }
 
}
