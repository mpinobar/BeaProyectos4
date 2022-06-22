using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickableItem : MonoBehaviour
{
    public abstract void ActivateEffect(RobertoController player);

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out RobertoController player))
        {
            ActivateEffect(player);
            Destroy(gameObject);
        }
    }
}
