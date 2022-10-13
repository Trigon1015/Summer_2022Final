using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newAggroStateData", menuName = "Data/State Data/Aggro State")]
public class D_AggroState : ScriptableObject
{
    public float movementSpeed = 0.8f;
    public float minMoveTime = 1f;
    public float maxMoveTime = 4f;
    public float strafeTime = 1f;

}
