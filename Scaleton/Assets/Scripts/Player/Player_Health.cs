using UnityEngine;
using UnityEngine.UI;
using TarodevController;
using TarodevController.Demo;
public class Player_Health : MonoBehaviour
{
    public float health;
    [SerializeField] Image healthBar;
    [SerializeField] GameObject coverScreen;
    [SerializeField] AudioSource sfx;
    [SerializeField] AudioSource hurtSfx;

    public bool isDead;

    private void Start()
    {
        health = 1;
        sfx.volume = 0;
    }
    public void TakeDamage()
    {
        health--;
        hurtSfx.Play();
        if(health <= 0)
        {
            isDead = true;
            PlayerPrefs.SetInt("victory", 0);
            coverScreen.GetComponent<Image>().color = Color.black;
            coverScreen.SetActive(true);
            sfx.volume = 1;
            GetComponent<PlayerController>().Stats.BaseSpeed = 0;
            GetComponent<PlayerController>().Stats.JumpPower = 0;
        }
    }

    private void Update()
    {
        healthBar.fillAmount = (float)(health / 5);
    }
}
