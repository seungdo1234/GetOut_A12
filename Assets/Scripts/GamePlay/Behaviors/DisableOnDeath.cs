using UnityEngine;

public class DisableOnDeath : MonoBehaviour
{
    public void OnDisableFlight()
    {
        ItemManager.Instance.DropInfo(transform.position);
        gameObject.SetActive(false);
    }

}
