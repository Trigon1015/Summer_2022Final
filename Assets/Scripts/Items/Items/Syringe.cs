using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Syringe : Item
{
    private int count;
    private int max = 13;
    public Syringe()
    {
        _name = "syringe";
        fullName = "Soldier's Syringe";
        description = "Increased attack speed.";
    }

    private void GetNum()
    {
        count = ItemManager.FindInstance().ItemCount(_name);
    }

    public float GetAttackSpeedBonus()
    {
        GetNum();
        if (count >= max)
        {
            return 0.15f * max;
        }
        else
        {
            return 0.15f * count;
        }
    }
}
