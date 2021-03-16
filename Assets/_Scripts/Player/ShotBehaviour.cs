using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBehaviour : SteerableBehaviour
{
    private void Update()
    {
        Thrust(1, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player")) return;
        IDamageable damageable = (IDamageable)collision.gameObject.GetComponent(typeof(IDamageable));
        if (!(damageable is null))
        {
            damageable.TakeDamage(1);
        }
        Destroy(gameObject);
    }
}
