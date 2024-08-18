using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TarodevController;
using TMPro;
public class Player_Milk : MonoBehaviour
{
    [SerializeField] GameObject powerTextParent;
    [SerializeField] GameObject boss;
    [SerializeField] GameObject wallZombie;
    [SerializeField] TextMeshProUGUI powerText;
    [SerializeField] TextMeshProUGUI expText;

    public int milkCount;
    string powerString;
    string expString;
    const float animLenght = 5f;
    PlayerStats stats;


    private void Awake()
    {
        QualitySettings.vSyncCount = 0;  
        Application.targetFrameRate = 60;
    }
    private void Start()
    {
        stats = GetComponent<PlayerController>().Stats;
        milkCount = 0;
        powerTextParent.SetActive(false);
        ResetPowers();
    }

    public void ResetPowers()
    {
        stats.AllowCrouching = false;
        stats.AllowDash = false;
        stats.AllowWalls = false;
        stats.MaxAirJumps = 0;
        stats.JumpPower = 15;
        stats.BaseSpeed = 10;
    }

    public void UpdateMilk(string power)
    {
        GetComponent<AudioSource>().Play();

        switch (power)
        {
            case "wallJump":
                powerString = "Wall Jump";
                expString = "Jump from walls!";
                Destroy(wallZombie);
                break;
            case "doubleJump":
                powerString = "Double Jump";
                expString = "Jump mid-air";
                break;
            case "dash":
                powerString = "Dash Jump";
                expString = "Press x to dash!";
                break; 
            case "moreJump":
                powerString = "Higher Jumps";
                expString = "Hold space to jump higher";
                break;
        }
        StartCoroutine(PlayTextAnim());
        milkCount++;
        GetComponent<Player_Health>().health++;
        PlayerPrefs.SetInt("milkCount", milkCount);
        //transform.localScale = new Vector2(transform.localScale.x + 0.4f, transform.localScale.x + 0.4f);
    }

    IEnumerator PlayTextAnim()
    {
        powerText.text = powerString + "!";
        expText.text = expString;
        powerTextParent.SetActive(true);
        yield return new WaitForSeconds(animLenght);
        powerTextParent.SetActive(false);
    }
}
