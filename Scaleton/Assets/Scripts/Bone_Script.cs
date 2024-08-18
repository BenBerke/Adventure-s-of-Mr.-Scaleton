using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bone_Script : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float damage = 12.5f;
    [SerializeField] float speed;
    [SerializeField] float rotSpeed;
    [SerializeField] bool antiBone;
    float r;
    private void Start()
    {
        transform.position = transform.parent.GetChild(0).transform.position;
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * speed);
    }

    private void Update()
    {
        r += rotSpeed/100;
        transform.rotation = Quaternion.Euler(15, 15, r);

        if(GameObject.FindGameObjectWithTag("Boss").GetComponent<Boss_Battle>().isDead) Destroy(gameObject); 
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Boss" && !antiBone)
        {
            collision.GetComponent<Boss_Battle>().TakeDamage(damage);
            Destroy(gameObject);
        }
        if (collision.tag == "Player" && antiBone)
        {
            collision.GetComponent<Player_Health>().TakeDamage();
            Destroy(gameObject);
        }
    }
}
