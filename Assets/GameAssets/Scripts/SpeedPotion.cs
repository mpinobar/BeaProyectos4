using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPotion : PickableItem
{
    public override void ActivateEffect(RobertoController player)
    {
        player.SpeedBoost();
    }
}
