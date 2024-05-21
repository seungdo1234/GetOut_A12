using UnityEngine;

public class DisableOnDeath : MonoBehaviour
{
    public void OnDisableScout()
    {
        gameObject.SetActive(false);
        ItemManager.Instance.DropInfo(this.gameObject);
    }
}
