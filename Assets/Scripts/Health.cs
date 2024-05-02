using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public static Health instance;
    public int health;
    public int numOfHeart;

    public float time;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    
    public GameObject deathEffect;

    [SerializeField]
    private GameObject GameOverUI;

    private void Update()
    {
        if (health > numOfHeart)
        {
            health = numOfHeart;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if (i < numOfHeart)
            {
                hearts[i].enabled = true;

            }
            else
            {
                hearts[i].enabled = false;
            }
        }

        time -= Time.deltaTime;
        if (health == 0)
        {
            Die();
        }

        if (true)
        {

        }

    }

    public void EndGame()
    {
        GameOverUI.SetActive(true);
    }
    void Die()
    {
        DeathEffect();
        this.gameObject.SetActive(false);
        DeathEffect();

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        EndGame();
    }
    public void Damage(int dmg)
    {
        health -= dmg;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Spike"))
        {
            if (time <= 0)
            {
                Damage(1);
                time = 1f;
            }
            
        }

        if (collision.CompareTag("Enemy"))
        {
            if (time <= 0)
            {
                Damage(1);
                time = 1f;
            }

        }
        
    }

    private void DeathEffect()
    {
        if (deathEffect != null)
        {
            GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
        }
    }
}
    

