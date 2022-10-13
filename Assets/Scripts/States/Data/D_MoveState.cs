using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newMoveStateData", menuName = "Data/State Data/Move State")]
public class D_MoveState : ScriptableObject //data container for saving data independent of class instances
{
    public float movementSpeed = 0.8f;
    public float minMoveTime = 1f;
    public float maxMoveTime = 4f;
}
