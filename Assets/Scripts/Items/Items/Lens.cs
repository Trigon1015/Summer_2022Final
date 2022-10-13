using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lens : Item
{
    private int count;

    public Lens()
    {
        _name = "lens";
        fullName = "Lens-Maker's Glasses";
        description = "Chance to do double damage.";
    }

    private void GetNum()
    {
        count = ItemManager.FindInstance().ItemCount(_name);
    }

    public float GetCritChance()
    {
        GetNum();
        return 0.07f * count;
    }
}
