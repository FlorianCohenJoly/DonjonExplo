using UnityEngine;

public class Vase : MonoBehaviour
{
    public bool isFilled = false;
    public RitualManager ritualManager;
    public Transform spawnPoint;
    public GameObject[] possibleObjects;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Le joueur est devant le vase.");

            if (!isFilled && Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Touche E pressée devant le vase.");

                PlayerInventory inventory = other.GetComponent<PlayerInventory>();
                if (inventory != null && inventory.items.Count > 0)
                {
                    string placedItem = inventory.items[0];
                    Debug.Log("On essaye de placer: " + placedItem);

                    inventory.RemoveItem(placedItem);

                    foreach (GameObject objPrefab in possibleObjects)
                    {
                        if (objPrefab.name == placedItem)
                        {
                            Debug.Log("Objet trouvé dans possibleObjects: " + objPrefab.name);
                            Instantiate(objPrefab, spawnPoint.position, spawnPoint.rotation, spawnPoint);
                            break;
                        }
                    }

                    isFilled = true;
                    ritualManager.CheckRitual();
                }
                else
                {
                    Debug.Log("Inventaire vide !");
                }
            }
        }
    }
}
