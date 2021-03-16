using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : SteerableBehaviour, IShooter, IDamageable
{

    private int enemyHealth;
    public GameObject bullet;
    public Transform enemyGun;
    GameManager gm;

    private void Start()
    {
        gm = GameManager.GetInstance();
        if (gameObject.CompareTag("asteroid")) enemyHealth = 2;
        else if (gameObject.CompareTag("enemies")) enemyHealth = 5;
    }

    public AudioClip shootSFX;

    public void Shoot()
    {
        if (gm.gameState != GameManager.GameState.GAME) return;
        Instantiate(bullet, enemyGun.position, Quaternion.identity);
        AudioManager.PlaySFX(shootSFX);
    }

    public void TakeDamage(int dmg)
    {
        enemyHealth -= dmg;
        gm.points += 10;
        if (enemyHealth <= 0) Die();

    }

    public void Die()
    {
        if (gameObject.CompareTag("asteroid")) gm.points += 100;
        else if (gameObject.CompareTag("enemies")) gm.points += 200;
        Destroy(gameObject);
    }
}
