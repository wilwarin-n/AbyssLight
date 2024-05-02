using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;

    public Animator animator;
    public GameObject deathEffect;
  

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            
            
            Die();
        }
        
    }

    void Die()
    {

        Debug.Log("Enemy died!");
        this.gameObject.SetActive(false);
        DeathEffect();
        
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;

    }

    private void DeathEffect()
    {
        if(deathEffect != null)
        {
            GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
        }
    }

    
}
