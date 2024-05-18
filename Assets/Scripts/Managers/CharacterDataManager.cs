using UnityEngine;

public class CharacterDataManager : MonoBehaviour
{
    public static CharacterDataManager Instance;

    [SerializeField] private PlayerData playerData;
    [SerializeField] private EnemyData enemy1ScoutData;
    public PlayerData PlayerData => playerData;
    public EnemyData Enemy1ScoutData => enemy1ScoutData;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}