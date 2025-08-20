using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    public GameObject item; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInventory inventory = other.GetComponent<PlayerInventory>();
            if (inventory != null)
            {
                inventory.AddItem(item.name);
                Destroy(gameObject);
            }
        }
    }
}
