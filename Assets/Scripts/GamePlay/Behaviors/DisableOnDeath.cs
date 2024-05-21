using UnityEngine;

public class DisableOnDeath : MonoBehaviour
{
    public void OnDisableFlight()
    {
        gameObject.SetActive(false);
        ItemManager.Instance.DropInfo(this.gameObject);
    }
}
