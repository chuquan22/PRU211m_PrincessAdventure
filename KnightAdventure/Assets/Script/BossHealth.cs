using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public Slider healthSlide;
    public int health = 500;

    public GameObject deathEffect;

    public bool isInvulnerable = false;


    private void Start()
    {
        healthSlide.maxValue = health;
        healthSlide.value = health;
    }

    public void TakeDamage(int damage)
    {
        if (isInvulnerable)
            return;

        health -= damage;
        //healthSlide.maxValue = health;
        healthSlide.value = health;
        health -= damage;

        /*if (health <= 200)
        {
            GetComponent<Animator>().SetBool("IsEnraged", true);
        }*/

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
