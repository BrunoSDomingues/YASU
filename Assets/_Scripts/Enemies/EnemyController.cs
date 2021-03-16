using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : SteerableBehaviour, IShooter, IDamageable
{

    private int enemyHealth;
    public GameObject bullet;
    public Transform enemyGun;

    private void Start()
    {
        if (gameObject.CompareTag("asteroid")) enemyHealth = 1;
        else if (gameObject.CompareTag("enemies")) enemyHealth = 2;
    }

    public AudioClip shootSFX;

    public void Shoot()
    {
        Debug.Log("Shooting");
        Instantiate(bullet, enemyGun.position, Quaternion.identity);
        AudioManager.PlaySFX(shootSFX);
    }

    public void TakeDamage(int dmg)
    {
        enemyHealth -= dmg;
        if (enemyHealth <= 0) Die();
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
