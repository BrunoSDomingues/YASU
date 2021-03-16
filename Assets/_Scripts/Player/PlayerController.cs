using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : SteerableBehaviour, IShooter, IDamageable
{
    Animator animator;
    private int health;

    private void Start()
    {
        animator = GetComponent<Animator>();
        health = 20;
    }

    public GameObject bullet;
    public Transform gun;
    private float shootDelay = 0.5f;
    private float _lastShootTimestamp = 0.0f;
    public AudioClip shootSFX;

    public void Shoot()
    {
        if (Time.time - _lastShootTimestamp < shootDelay) return;
        AudioManager.PlaySFX(shootSFX);
        _lastShootTimestamp = Time.time;

        Instantiate(bullet, gun.position, Quaternion.identity);
    }

    public void TakeDamage(int dmg)
    {
        health -= dmg;
        Debug.Log("Current health: " + health);
        if (health <= 0) Die();
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("asteroid"))
        {
            Destroy(collision.gameObject);
            TakeDamage(1);
        }

        if (collision.CompareTag("enemies"))
        {
            Destroy(collision.gameObject);
            TakeDamage(2);
        }
    }

    void FixedUpdate()
    {
        float yInput = Input.GetAxis("Vertical");
        float xInput = Input.GetAxis("Horizontal");
        Thrust(xInput, yInput);
        if (yInput != 0 || xInput != 0)
        {
            animator.SetFloat("Velocity", 1.0f);
        }
        else
        {
            animator.SetFloat("Velocity", 0.0f);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            Shoot();
        }
    }
}
