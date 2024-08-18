using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TarodevController;
using DialogueEditor;
public class Milk_Power : MonoBehaviour
{
    float lastJumpPower;
    public PowerType powerType;
    public enum PowerType
    {
        wallJump,
        doubleJump,
        dash,
        moreJump
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerStats stats = collision.GetComponent<PlayerController>().Stats;
            lastJumpPower = stats.JumpPower;
            switch (powerType)
            {
                case PowerType.wallJump:
                    stats.AllowWalls = true;
                    break;
                case PowerType.doubleJump:
                    stats.MaxAirJumps = 1;
                    break;
                case PowerType.dash:
                    stats.AllowDash = true;
                    break;
                case PowerType.moreJump:
                    stats.JumpPower = 18.9f;
                    break;
            }

            if (stats.JumpPower > lastJumpPower + 3.9f) stats.JumpPower = lastJumpPower + 3.9f;

            collision.GetComponent<Player_Milk>().UpdateMilk(powerType.ToString());
            Destroy(transform.parent.gameObject);
        }
    }

}
