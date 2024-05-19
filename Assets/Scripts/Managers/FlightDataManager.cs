using UnityEngine;

public class FlightDataManager : MonoBehaviour
{
    public static FlightDataManager Instance;

    [SerializeField] private PlayerData playerData;
    public PlayerData PlayerData => playerData;
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