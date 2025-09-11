using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    [Header("Prefab qui sera stocké dans l'inventaire")]
    public GameObject itemPrefab;

    /*    private void OnTriggerEnter(Collider other)
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
       } */

    // ramasser l'item en appuyant sur la touche F
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, 2f);
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.CompareTag("Player"))
                {
                    PlayerInventory inventory = hitCollider.GetComponent<PlayerInventory>();
                    if (inventory != null && itemPrefab != null)
                    {
                        inventory.AddItem(itemPrefab);
                        Destroy(gameObject);
                        break;
                    }
                }
            }
        }
    }





}
