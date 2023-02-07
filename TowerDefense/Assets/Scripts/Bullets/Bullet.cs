using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Range(0, 100)] public float Speed = 50f;

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
    }

    private void HitTarget()
    {
        //Debug.Log("Touché");
        GameObject effectins = Instantiate(bulletimpactEffect, transform.position, transform.rotation);
        Destroy(effectins, 2f);
        Destroy(gameObject);
    }
}
