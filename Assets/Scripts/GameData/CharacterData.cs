using UnityEngine;

public class CharacterData : MonoBehaviour, IDamageable
{
    [Header("# Character Stat")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float atkDelay;
    [SerializeField] private float atkDamage;
    [SerializeField] private float maxHealth;
    [SerializeField] private float curHealth;
    [SerializeField] private int bulletNum;
    [SerializeField] private float bulletAngle;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private EFlightStatus Eflightstatus;
    
    public float MoveSpeed => moveSpeed;
    public float AtkDamage => atkDamage;
    public float AtkDelay => atkDelay;
    public float MaxHealth => maxHealth;
    public int BulletNum => bulletNum;
    public float BulletAngle => bulletAngle;
    public float BulletSpeed => bulletSpeed;
    public EFlightStatus EFlightStatus => Eflightstatus;
    
    // 따로 빼야한다.
    public void TakeDamage(float damage)
    {
        if (curHealth - damage >= 0)
        {
            curHealth -= damage;   
        }
        else
        {
            // 게임오버
            Eflightstatus = EFlightStatus.Dead;
            // 여기서 CallDeathEvent를 호출해야한다.
        }
    }
}
