using UnityEngine;

[CreateAssetMenu(fileName = "CircularAttackSO", menuName = "Attacks/Circular", order = 1)]
public class CircularAttackSO : AttackSO
{
    [Header("CircularAttack Info")]
    public float AnglePerFire;
}
