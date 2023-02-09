using System;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [Space(25f)]
    [Header("References")]

    public Transform partToRotate;
    public GameObject bulletPrefab;
    public Transform firePoint;

    [Space(25f)]
    [Header("Stats")]

    [SerializeField] [Range (0, 100)] private float turnSpeed = 10f;
    [SerializeField] [Range (0, 300)] private float fireCountDown = 0f;
    [Range(0, 100)] public float fireRate = 1f;
    [Range(0, 300)] public float range = 15f;

    [Space(25f)]
    [Header("Others")]

    [SerializeField] private Transform target;
    public string enemyTag = "Enemy";
    public bool useLaser;
    public LineRenderer lineRenderer;
    public ParticleSystem impactEffect;
    public Light impactLight;


    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    private void Update()
    {
        if (target == null)
        {
            if (useLaser && lineRenderer.enabled)
            {
                lineRenderer.enabled = false;
                impactLight.enabled = false;
                impactEffect.Stop();
            }
            //Debug.Log("target = " + target);
            return;
        }

        lockOnTarget();

        if (useLaser)
        {
            Laser();
        }
        else
        {
            if (fireCountDown <= 0)
            {
                Shoot();
                fireCountDown = 1 / fireRate;
            }
            fireCountDown -= Time.deltaTime;
        }
    }

    private void lockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        //Debug.Log("rotation = " + rotation);
    }

    private void Laser()
    {
        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            impactLight.enabled = false;
            impactEffect.Play();
        }
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);

        Vector3 dir = firePoint.position - target.position;
        impactEffect.transform.rotation = Quaternion.LookRotation(dir);

        impactEffect.transform.position = target.position + dir.normalized * 1.5f;
    }

    private void Shoot()
    {
        //Debug.Log("Piouuu !!");
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }

    private void UpdateTarget()
    {
        GameObject[] ennemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in ennemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            //Debug.Log("new target");
        }
        else
        {
            target = null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
