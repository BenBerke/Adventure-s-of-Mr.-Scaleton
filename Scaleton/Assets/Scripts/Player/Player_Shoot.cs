using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shoot : MonoBehaviour
{
    [SerializeField] GameObject bone;
    [SerializeField] float coolDown;
    float c;

    [SerializeField] AudioSource shootSFX;
    private void Start()
    {
        GetComponent<Player_Shoot>().enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && c + coolDown < Time.time)
        {
            c = Time.time;
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(bone, transform);
        shootSFX.Play();
    }
}
