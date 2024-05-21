public enum EEnemyType
{
    Default,
    Scout, //잡몹1
}

// Flight가 살아있는지 죽어있는지의 상태를 나타낼 enum
// >> 차후 여러 형태를 추가할 수 있을 것 같아 enum으로 사용
public enum EFlightStatus
{
    Alive,
    Dead,
}

public enum EPoolObjectType
{
    Default,
    Bullet,
    Enemy
}

public enum EWeaponType
{
    Defalut,
    AutoCannon,
    Rockets,
    Zapper
}
