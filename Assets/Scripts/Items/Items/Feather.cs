using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feather : Item
{
    private int totalJumps;
    private int jumpsLeft;

    private int max = 7;

    public Feather()
    {
        _name = "feather";
        fullName = "Hopoo Feather";
        description = "Gain another jump.";
    }

    public void ResetExtraJumps()
    {
        totalJumps = ItemManager.FindInstance().ItemCount(_name);
        if (totalJumps >= max)
        {
            jumpsLeft = max;
        }
        else
        {
            jumpsLeft = totalJumps;
        }
    }

    public bool CanExtraJump()
    {
        if (jumpsLeft > 0)
        {
            jumpsLeft--;
            return true;
        }
        else
        {
            return false;
        }
    }
}
