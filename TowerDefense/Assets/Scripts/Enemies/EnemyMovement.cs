using UnityEngine;

[RequireComponent(typeof(EnnemyController))]
public class EnemyMovement : MonoBehaviour
{
    [Space(25f)]
    [Header("Refs")]

    private EnnemyController enemy;
    
    [Space(25f)]
    [Header("Others")]

    [SerializeField] private Transform target;
    [SerializeField] private int waypointIndex = 0;


    private void Start()
    {
        enemy = GetComponent<EnnemyController>();
        target = Waypoints.points[0];
    }

    private void Update()
    {
        MoveToTarget();
        enemy.speed = enemy.baseSpeed;
    }

    private void MoveToTarget()
    {
        //Move the enemy to the target
        Vector3 dir = target.position - transform.position;
        transform.Translate(enemy.speed * Time.deltaTime * dir.normalized, Space.World);

        if (Vector3.Distance(transform.position, target.position) > enemy.targetReachedDist)
        {
            return;
        }
        GetNextWaypoint();
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
