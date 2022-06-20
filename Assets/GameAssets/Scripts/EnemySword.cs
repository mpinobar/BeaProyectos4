using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySword : MonoBehaviour
{
    [SerializeField] int swordDamage = 1;
    bool hasDealtDamage = false;

    private void OnEnable()
    {
        hasDealtDamage = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!hasDealtDamage)
        {
            other.TryGetComponent(out Health enemigo);
            if (enemigo)
            {
                enemigo.TakeDamage();
                hasDealtDamage = true;
                gameObject.SetActive(false);
            }
        }
    }
}
