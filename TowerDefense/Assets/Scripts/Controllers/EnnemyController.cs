using System;
using UnityEngine;

public class EnnemyController : MonoBehaviour
{
    [Space(25f)]
    [Header("Enemy stats")]

    [Range(0,100)] public float speed;
    [Range(0,1)]   public float targetReachedDist;

    [Space(25f)]
    [Header("Others")]

    [SerializeField] private Transform target;
    [SerializeField] private int waypointIndex;

    [Space(25f)]
    [Header("References")]

    public EnnemyData ennemyData;


    private void Start()
    {
        target = Waypoints.points[0];
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
            Destroy(gameObject);
            return;
        }
        waypointIndex++;
        target = Waypoints.points[waypointIndex];
    }
}
