using System;
using UnityEngine;

public class EnnemyController : MonoBehaviour
{
    [Space(25f)]
    [Header("Stats")]

    [HideInInspector] public float speed;
    [Range(0,1)]      public float targetReachedDist;
    [Range(0, 100)]   public float baseSpeed;
    [Range(0,50000)]  public float health = 100f;
    [Range(0,10000)]  public int moneyDrop = 50;

    [Space(25f)]
    [Header("References")]

    public EnnemyData ennemyData;
    public GameObject deathEffect;

    private void Start()
    {
        speed = baseSpeed;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Die();
            //Debug.Log(health);
        }
    }

    internal void Slow(float slowPrcnt)
    {
        speed = baseSpeed * (1 - slowPrcnt);
    }

    private void Die()
    {
        PlayerStats.money += moneyDrop;
        GameObject deathParticles = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(deathParticles,1f);
        Destroy(gameObject);
    }
}
