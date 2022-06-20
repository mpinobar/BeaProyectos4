using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out RobertoController player) && player.hasChestKey)
        {
            GetComponent<Animator>().SetBool("Open", true);
            player.hasDoorKey = true;
        }
    }
}
