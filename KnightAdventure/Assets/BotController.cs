using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class BotController : MonoBehaviour
{
    private Animator m_animator;
    private Rigidbody2D m_body2d;
    public Transform Player;
    
    public float speed;
    public static event Action OnBotDeath;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public int attackDamage = 10;


    public static int maxHealth = 100;
    int currentHeath;

    public Transform groundCheck;
    public float grondCheckRadius = 0.1f;
    public LayerMask groundLayer;


    // Start is called before the first frame update
    void Start()
    {
        m_animator = GetComponent<Animator>();
        m_body2d = GetComponent<Rigidbody2D>();
        currentHeath = maxHealth;

    }

    // Update is called once per frame
    void Update()
    {

        if (Vector2.Distance(Player.position, attackPoint.position) <= attackRange && DataPlayer.currentHeath >0)
        {
            m_animator.SetTrigger("attack");

        }
        else
        {

            m_animator.ResetTrigger("attack");
            transform.Translate(Time.deltaTime * speed * transform.right);

            if (!Physics2D.OverlapCircle(groundCheck.position, grondCheckRadius, groundLayer) || Physics2D.OverlapCircle(attackPoint.position, grondCheckRadius, groundLayer))
            {
                Flip();
            }
        }

        
    }

    private void Flip()
    {
        Vector3 scale = transform.localScale;
        if (scale.x == -1)
        {
            scale.x = 1;
        }else
        {
            scale.x = -1;
        }
        
        transform.localScale= scale;

        speed *= -1;
    }
    public void TakeDamage(int damage)
    {
        currentHeath -= damage;
        
        Debug.Log("HP bot:" + currentHeath);

        if (currentHeath <= 0)
        {
            Die();
        }

    }

    private void botAttack()
    {
        // set animation attack
        m_animator.SetTrigger("attack");

        // detack enermy in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //Damage
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<playerController>().TakeDamage(attackDamage);
        }

    }

    public void Die()
    {
        OnBotDeath?.Invoke();
        GameObject.Destroy(this.gameObject);
        Debug.Log("die");
    }

    
   

    
}
