using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : PickableItem
{
    public override void ActivateEffect(RobertoController player)
    {
        player.RestoreHealth();
    }   
}
