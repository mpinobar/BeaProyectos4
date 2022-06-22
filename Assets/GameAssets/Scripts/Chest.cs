using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] GameObject canvasLlavePuerta;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out RobertoController player) && player.hasChestKey)
        {
            GetComponent<Animator>().SetBool("Open", true);
            player.hasDoorKey = true;
            GameObject canvas = Instantiate(canvasLlavePuerta);
            Destroy(canvas, 5);
        }
    }
}
