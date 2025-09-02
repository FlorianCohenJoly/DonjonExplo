using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    [Header("Prefab qui sera stocké dans l'inventaire")]
    public GameObject itemPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInventory inventory = other.GetComponent<PlayerInventory>();
            if (inventory != null && itemPrefab != null)
            {

                inventory.AddItem(itemPrefab);


                Destroy(gameObject);
            }
        }
    }
}
