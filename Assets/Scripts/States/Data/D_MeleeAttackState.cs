using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newMeleeAttackStateData", menuName = "Data/State Data/Melee Attak State")]
public class D_MeleeAttackState : ScriptableObject
{
    public float attackRadius = 0.1f;
    public int attackDamage = 10;
    public LayerMask whatIsPlayer;

}
