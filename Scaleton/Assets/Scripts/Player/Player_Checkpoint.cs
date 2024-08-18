using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Checkpoint : MonoBehaviour
{
    Transform lastCheckpoint;
    [SerializeField] AudioSource deathSFX;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Checkpoint":
                lastCheckpoint = collision.transform;
                break;
            case "Spike":
                Death();
                break;
        }
    }

    void Death()
    {
        print("death");
        transform.position = lastCheckpoint.position;
        deathSFX.Play();
    }
}
