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

    public int combo;
    public bool IsCombo;
    public int NoOfClick = 0;
    public float lastClickTime = 0;
    public float maxComboDelay = 0.9f;

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
            m_animator.SetInteger("Attack", 1);

        }
        else
        {
            m_animator.SetInteger("Attack", 0);
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

    public void ComboAttack()
    {
        if(Input.GetMouseButtonDown(0) && !IsCombo)
        {
            IsCombo = true;
            m_animator.SetInteger("Attack", combo);
           
        }
    }

    public void StartCombo()
    {
        IsCombo = false;
        if(combo < 4)
        {
            combo++;
        }
    }

    public void FinishCombo()
    {
        IsCombo = false;

    }

    private void heroAttack()
    {
        // set animation attack
        

        // detack enermy in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //Damage
        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemyLayers.Equals("enermy"))
            {
                enemy.GetComponent<BotController>().TakeDamage(DataPlayer.attackDamage);
            }
            else
            {
                enemy.GetComponent<BossHealth>().TakeDamage(DataPlayer.attackDamage);
            }
           

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
/*        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        m_body2d.bodyType = RigidbodyType2D.Static;*/
        Debug.Log("die");
        Invoke("GameOver",2f);
        
    }

    public void GameOver()
    {
      SceneManager.LoadScene("GameOver");
      PlayerPrefs.DeleteAll();
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
            dataTransmissionPlayer();
            dataTransmissionBot();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
        else
        {
            PlayerPrefs.DeleteAll();
        }
    }


    public void dataTransmissionPlayer()
    {
        PlayerPrefs.SetInt("HP", DataPlayer.currentHeath);
        PlayerPrefs.SetInt("MaxHP", DataPlayer.maxHealth);
        PlayerPrefs.SetInt("Exp", DataPlayer.valueExp);
        PlayerPrefs.SetInt("MaxExp", DataPlayer.maxValueExp);
        PlayerPrefs.SetInt("Damage", DataPlayer.attackDamage);
        PlayerPrefs.SetInt("Level", DataPlayer.level);
    }

    public void dataTransmissionBot()
    {
        PlayerPrefs.SetInt("HPBot", DataBot.Health + 50);
        PlayerPrefs.SetInt("BotDamage", DataBot.Attack + 5);
    }

}
