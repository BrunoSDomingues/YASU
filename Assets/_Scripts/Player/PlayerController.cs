using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : SteerableBehaviour, IShooter, IDamageable
{
    Animator animator;
    GameManager gm;

    private void Start()
    {
        animator = GetComponent<Animator>();
        gm = GameManager.GetInstance();
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
        gm.playerHealth -= dmg;
        if (gm.playerHealth <= 0) Die();
    }

    public void Die()
    {
        if (gm.gameState == GameManager.GameState.GAME) gm.ChangeState(GameManager.GameState.ENDGAME);
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
        if (gm.gameState != GameManager.GameState.GAME) return;
        else
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
}
