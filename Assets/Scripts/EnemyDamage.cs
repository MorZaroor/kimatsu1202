using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float destroyThresholdY = -500f;
    public HPController hpController;

    private void Start()
    {
        if (hpController == null)
        {
            hpController = FindObjectOfType<HPController>();
        }
    }
    private void Update()
    {
        if (transform.position.y < destroyThresholdY)
        {
            hpController.TakeDamage();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            hpController.TakeDamage();
            Destroy(gameObject);
        }
    }
}
