using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    [Header("Prefab qui sera stocké dans l'inventaire")]
    public GameObject itemPrefab; // Drag ton prefab ici dans l’inspecteur

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInventory inventory = other.GetComponent<PlayerInventory>();
            if (inventory != null && itemPrefab != null)
            {
                // On ajoute le PREFAB dans l'inventaire
                inventory.AddItem(itemPrefab);

                // On détruit seulement l'objet ramassable de la scène
                Destroy(gameObject);
            }
        }
    }
}
