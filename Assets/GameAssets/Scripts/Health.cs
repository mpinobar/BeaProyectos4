using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;
    Animator animator;
    public float tiempoRecargaEscena = 3;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    public void TakeDamage()
    {
        currentHealth--;
        animator.SetTrigger("ReceiveDamage");

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        animator.SetBool("isDead",true);
        Invoke(nameof(RecargarEscena),tiempoRecargaEscena);
    }

    private void RecargarEscena()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
