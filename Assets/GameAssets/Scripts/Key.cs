using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {        
        if(other.TryGetComponent(out RobertoController player))
        {
            player.hasChestKey = true;
            Destroy(gameObject);
        }
    }
}
