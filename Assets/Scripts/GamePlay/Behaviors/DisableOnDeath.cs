using UnityEngine;

public class DisableOnDeath : MonoBehaviour
{
    public void OnDisableScout()
    {
        gameObject.SetActive(false);
    }

}
