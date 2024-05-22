using UnityEngine;

[CreateAssetMenu(fileName = "DefaultAttackSO", menuName = "Attacks/Default", order = 0)]
public class AttackSO : ScriptableObject
{
    [Header("Bullet Info")]
    public int BulletNum;
    public float BulletAngle;
    public float BulletSpeed;

    [Header("Attack Info")]
    public int AtkDamage;
    public float AtkDelay;
    

    [Header("# Bullet Animator")]
    public RuntimeAnimatorController BulletAnimator;
}
