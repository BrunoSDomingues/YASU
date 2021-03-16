using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotBehaviour : SteerableBehaviour
{
    private Vector3 direction;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("asteroid") || collision.CompareTag("enemies") || collision.CompareTag("shot")) return;

        IDamageable damageable = (IDamageable)collision.gameObject.GetComponent(typeof(IDamageable));
        if (!(damageable is null))
        {
            damageable.TakeDamage(1);
        }
        Destroy(gameObject);
    }

    void Start()
    {
        Vector3 posPlayer = GameObject.FindWithTag("player").transform.position;
        direction = (posPlayer - transform.position).normalized;
    }

    void Update()
    {
        Thrust(direction.x, direction.y);
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
