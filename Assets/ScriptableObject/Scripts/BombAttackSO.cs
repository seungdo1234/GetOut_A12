using UnityEngine;

[CreateAssetMenu(fileName = "BombAttackSO", menuName = "Attacks/Bomb", order = 2)]
public class BombAttackSO : AttackSO
{
    [Header("BombAttack Info")]
    public float BombSpeed;
    public float ExplodeDelay;
}
