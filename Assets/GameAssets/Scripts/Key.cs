using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : PickableItem
{
    [SerializeField] GameObject canvasLlaveCofre;
    public override void ActivateEffect(RobertoController player)
    {
        player.hasChestKey = true;
        GameObject canvas = Instantiate(canvasLlaveCofre);
        Destroy(canvas, 5);
    }
}
