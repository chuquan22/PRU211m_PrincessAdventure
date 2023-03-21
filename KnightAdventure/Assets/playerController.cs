using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    [SerializeField] float m_speed = 4.0f;
    private Animator m_animator;
    private Rigidbody2D m_body2d;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

   
    private bool grounded = false;
    public int jumpHeight = 15;

    // Start is called before the first frame update
    void Start()
    {
        m_animator = GetComponent<Animator>();
        m_body2d = GetComponent<Rigidbody2D>();
        Debug.Log("HP :" + DataPlayer.currentHeath);
        Debug.Log("MaxHP :" + DataPlayer.maxHealth);
        Debug.Log("Exp :" + DataPlayer.valueExp);
    }

    


    // Update is called once per frame
    void Update()
    {

        // -- Handle input and movement --
        float inputX = Input.GetAxis("Horizontal");

        // Swap direction of sprite depending on walk direction
        if (inputX > 0)
        {
            transform.localScale = new Vector3(5.0f, 5.0f, 1.0f);
            m_animator.SetFloat("Speed", 1);
        }
        else if (inputX < 0)
        {
            transform.localScale = new Vector3(-5.0f, 5.0f, 1.0f);
            m_animator.SetFloat("Speed", 1);
        }
        else
        {
            m_animator.SetFloat("Speed", 0);
        }

        // Move
        m_body2d.velocity = new Vector2(inputX * m_speed, m_body2d.velocity.y);

        // enter mouse left to hero attack 
        if (Input.GetMouseButtonDown(0))
        {
            m_animator.SetTrigger("attack");
            
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (grounded)
            {
                grounded = false;
                m_body2d.velocity = new Vector2(m_body2d.velocity.x, jumpHeight);
                m_animator.SetBool("IsJumping", true);
            }

        }
    }

    private void heroAttack()
    {
        // set animation attack
        

        // detack enermy in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //Damage
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<BotController>().TakeDamage(DataPlayer.attackDamage);
        }

    }

    

    public void TakeDamage(int damage)
    {
        m_animator.SetTrigger("IsHurting");
        DataPlayer.currentHeath -= damage;
        HealthBar.SettingHealth(DataPlayer.currentHeath);
        Debug.Log("HP hero:" + DataPlayer.currentHeath);

        if (DataPlayer.currentHeath <= 0)
        {
            Die();
        }

    }

    public void Die()
    {
        m_animator.SetBool("IsAlive", false);
        
        //GameObject.Destroy(this.gameObject);
        Debug.Log("die");
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            grounded = true;
            m_animator.SetBool("IsJumping", false);
        }
        if (other.gameObject.tag == "Heart")
        {
            HealthBar.Heart();
        }
        if (other.gameObject.tag == "Finish")
        {
            PlayerPrefs.SetInt("HP", DataPlayer.currentHeath);
            PlayerPrefs.SetInt("MaxHP", DataPlayer.maxHealth);
            PlayerPrefs.SetInt("Exp", DataPlayer.valueExp);
            PlayerPrefs.SetInt("MaxExp", DataPlayer.maxValueExp);
            PlayerPrefs.SetInt("Damage", DataPlayer.attackDamage);
            PlayerPrefs.SetInt("Level", DataPlayer.level);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
        else
        {
            PlayerPrefs.DeleteAll();
        }
    }


}
