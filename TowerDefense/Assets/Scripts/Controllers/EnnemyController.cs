using System;
using UnityEngine;

public class EnnemyController : MonoBehaviour
{
    [Space(25f)]
    [Header("Enemy stats")]

    [Range(0,100)]   public float speed;
    [Range(0,1)]     public float targetReachedDist;
    [Range(0,50000)] public float health = 100;
    [Range(0,10000)] public int moneyDrop = 50;

    [Space(25f)]
    [Header("Others")]

    [SerializeField] private Transform target;
    [SerializeField] private int waypointIndex;

    [Space(25f)]
    [Header("References")]

    public EnnemyData ennemyData;
    public GameObject deathEffect;


    private void Start()
    {
        target = Waypoints.points[0];
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

    private void Die()
    {
        PlayerStats.money += moneyDrop;
        GameObject deathParticles = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(deathParticles,1f);
        Destroy(gameObject);
    }

    private void Update()
    {
        MoveToTarget(target);
    }

    private void MoveToTarget(Transform _target)
    {
        //Move the enemy to the target
        Vector3 dir = _target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        
        if(Vector3.Distance(transform.position, _target.position) <= targetReachedDist)
        {
            GetNextWaypoint();
        }
    }

    private void GetNextWaypoint()
    {
        //Actualise la target tant que l'ennemi n'est pas arrivé à la fin
        if (waypointIndex >= Waypoints.points.Length - 1)
        {
            //L'ennemi arrive à la fin
            EndPath();
            return;
        }
        waypointIndex++;
        target = Waypoints.points[waypointIndex];
    }

    private void EndPath()
    {
        PlayerStats.lives--;
        Destroy(gameObject);
    }
}
