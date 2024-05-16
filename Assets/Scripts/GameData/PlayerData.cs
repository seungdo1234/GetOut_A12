using UnityEngine;

public class PlayerData : CharacterData
{
    [Header("# Player Stat")]
    [SerializeField] private string playerName;
    [SerializeField] private int power;
    [SerializeField] private int bulletNum;
    [SerializeField] private float bulletAngle;


    public void PowerUp()
    {
        power++;
    }
}