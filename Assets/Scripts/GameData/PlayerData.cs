using UnityEngine;

public class PlayerData : FlightData
{
    [Header("# Player Stat")]
    [SerializeField] private string playerName;
    [SerializeField] private int power;
    [SerializeField] private EWeaponType weaponType;

    public void PowerUp()
    {
        power++;
    }

    public void WeaponChange(EWeaponType weaponType)
    {
        this.weaponType = weaponType;
    }
    
}