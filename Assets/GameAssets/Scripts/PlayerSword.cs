using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSword : MonoBehaviour
{
    [SerializeField] public int swordDamage;
    bool hasDealtDamage = false;

    private void OnEnable()
    {
        hasDealtDamage = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!hasDealtDamage)
        {
            other.TryGetComponent(out Enemy enemigo);
            if (enemigo)
            {
                enemigo.TakeDamage();
                hasDealtDamage = true;
                gameObject.SetActive(false);
            }
        }
    }
}
