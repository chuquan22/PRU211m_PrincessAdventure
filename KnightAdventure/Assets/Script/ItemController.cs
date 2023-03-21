using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    BoxCollider2D boxColliderbox ;

    private void Start()
    {
        boxColliderbox= GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        if(DataPlayer.currentHeath == DataPlayer.maxHealth)
        {
            boxColliderbox.isTrigger = true;
        }
        else
        {
            boxColliderbox.isTrigger = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            HealthBar.Heart();
            GameObject.Destroy(this.gameObject);
        }
    }
}
