using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public GameObject hitEffect;
    public GameManager gameManager;

    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, 90);
        if (gameManager == null)
        {
            gameManager = FindObjectOfType<GameManager>();
        }
    }

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime, Space.World);

        if (transform.position.y > 600f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            DestroyEnemy(other);
        }
    }

    void DestroyEnemy(Collider2D enemy)
    {
        Instantiate(hitEffect, enemy.transform.position, Quaternion.identity);
        ScoreManager.Instance.AddScore(10);
        gameManager.UpdateScoreUI();
        Destroy(enemy.gameObject);
        Destroy(gameObject);
    }
}
