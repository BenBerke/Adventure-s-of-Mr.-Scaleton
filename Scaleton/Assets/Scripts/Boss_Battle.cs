using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Boss_Battle : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] float attackSpeed;

    [SerializeField] Image healthBar;
    [SerializeField] AudioSource hurtSFX;
    [SerializeField] AudioSource attackSFX;
    [SerializeField] AudioSource deathSFX;

    [SerializeField] GameObject bone;
    [SerializeField] GameObject pfx;
    [SerializeField] GameObject coverScreen;

    [SerializeField] Animator anim;

    public bool isDead;

    private void Start()
    {
        pfx.SetActive(false);
        anim.enabled = false;
        isDead = false;
        deathSFX.volume = 0;
    }
    public void StartAttack()
    {
        InvokeRepeating("Attack", attackSpeed, attackSpeed);
    }

    void Attack()
    {
        if (isDead) return;
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Health>().isDead) return;
        Instantiate(bone, transform);
        attackSFX.Play();
        coverScreen.SetActive(false);
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        healthBar.fillAmount = health / 100;
        hurtSFX.Play();
        if (health <= 0) Death();
        StartCoroutine(VFX());
    }

    void Death()
    {
        isDead = true;
        deathSFX.volume = 1;
        PlayerPrefs.SetInt("victory", 1);
        pfx.SetActive(true);
        anim.enabled = true;
    }

    public void CoverScreen()
    {
        coverScreen.SetActive(true);
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(2);
    }
    IEnumerator VFX()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(.1f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }

}
