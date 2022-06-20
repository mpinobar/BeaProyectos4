using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out RobertoController player) && player.hasDoorKey)
        {
            SceneManager.LoadScene("Level_02");
        }
    }
}
