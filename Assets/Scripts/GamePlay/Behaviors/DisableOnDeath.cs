using UnityEngine;

public class DisableOnDeath : MonoBehaviour
{
    public void OnDisableFlight()
    {
        gameObject.SetActive(false);
    }

}
