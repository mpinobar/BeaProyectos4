using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;
    Animator animator;
    public float tiempoRecargaEscena = 3;
    [SerializeField] Image uiHealthbar;
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
        
        uiHealthbar.fillAmount = ((float)currentHealth) / maxHealth;
        if (currentHealth <= 0)
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

    public void RestoreHP()
    {
        Debug.Log("Player drank hp pot");
        currentHealth = maxHealth;
        uiHealthbar.fillAmount = ((float)currentHealth) / maxHealth;
    }
}
