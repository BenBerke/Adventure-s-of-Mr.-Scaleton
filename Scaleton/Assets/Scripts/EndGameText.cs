using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameText : MonoBehaviour
{
    [SerializeField] GameObject allMilkVictory;
    [SerializeField] GameObject allMilkDeath;
    [SerializeField] GameObject lessMilkVictory;
    [SerializeField] GameObject lessMilkDeath;
    [SerializeField] GameObject bugCase;

    [SerializeField] GameObject allMilkVictoryScene;
    [SerializeField] GameObject allMilkDeathScene;
    [SerializeField] GameObject lessMilkVictoryScene;
    [SerializeField] GameObject lessMilkDeathScene;

    [SerializeField] AudioSource music;

    private void Start()
    {
        music.volume = 0;
        print("milk " + PlayerPrefs.GetInt("milkCount"));
        print("victory " + PlayerPrefs.GetInt("victory"));
        allMilkDeath.SetActive(false);
        allMilkVictory.SetActive(false);
        lessMilkVictory.SetActive(false);
        lessMilkDeath.SetActive(false);
        allMilkDeathScene.SetActive(false);
        allMilkVictoryScene.SetActive(false);
        lessMilkVictoryScene.SetActive(false);
        lessMilkDeathScene.SetActive(false);
        bugCase.SetActive(false);
        switch (PlayerPrefs.GetInt("milkCount"))
        {
            case 3:
                if (PlayerPrefs.GetInt("victory") == 1)
                {
                    music.volume = 1;
                    lessMilkVictory.SetActive(true);
                    lessMilkVictoryScene.SetActive(true);
                }
                else
                {
                    lessMilkDeath.SetActive(true);
                    lessMilkDeathScene.SetActive(true);
                }
                break;
            case 4:
                if (PlayerPrefs.GetInt("victory") == 1)
                {
                    music.volume = 1;
                    allMilkVictory.SetActive(true);
                    allMilkVictoryScene.SetActive(true);
                }
                else 
                { 
                    allMilkDeath.SetActive(true); 
                    allMilkDeathScene.SetActive(true); 
                }
                break;


            default:
                bugCase.SetActive(true);
                break;
        }
    }
}
