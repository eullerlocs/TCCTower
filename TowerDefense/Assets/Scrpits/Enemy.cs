using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;

    [HideInInspector]
    public float speed;

    public float enemyHealth = 100f;

    public int deathEnergy = 10;

    public GameObject deathEffect;
  
    void Start()
    {
        speed = startSpeed;
    }

    public void TakeDamage(float amount)
    {
        enemyHealth -= amount;

        if (enemyHealth <= 0f)
        {
            Die();
        }
    }   

    void Die()
    {
        PlayerStats.Energy += deathEnergy;

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 4f);      

        Destroy(gameObject);
    }

    public void Slow(float pct)
    {
        speed = startSpeed * (1f - pct);
    }
}
