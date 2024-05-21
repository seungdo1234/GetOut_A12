using UnityEngine;

public class FlightData : MonoBehaviour
{
    [Header("# Fligth Stat")]
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
}
