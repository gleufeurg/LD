using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Space(25f)]
    [Header("Stats")]

    [Range(0, 100)] public float Speed = 50f;
    [Range(0, 100)] public float explosionRadius = 0f;
    [Range(0, 10000)] public float damage = 50f;

    [Space(25f)]
    [Header("References")]

    public GameObject bulletimpactEffect;
    private Transform target;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = Speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

    private void HitTarget()
    {
        //Debug.Log("Touché");
        GameObject effectins = Instantiate(bulletimpactEffect, transform.position, transform.rotation);
        Destroy(effectins, 2f);

        if(explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }
        Destroy(gameObject);
    }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if(collider.tag == "Enemy")
                Damage(collider.transform);
        }
    }

    private void Damage(Transform enemy)
    {
        EnnemyController e = enemy.GetComponent<EnnemyController>();
        if (e != null)
        {
            e.TakeDamage(damage);
            //Debug.Log(damage);
        }
        else
        {
            Debug.LogError("Pas de script EnnemyController sur l'ennemi !!");
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
