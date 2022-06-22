using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePotion : PickableItem
{
    public override void ActivateEffect(RobertoController player)
    {
        player.DamageBuff();
    }

    
}
