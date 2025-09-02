using UnityEngine;

public class Vase : MonoBehaviour
{
    public bool isFilled = false;
    public RitualManager ritualManager;
    public Transform spawnPoint;

    private void OnTriggerStay(Collider other)
    {
        if (!isFilled && other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("[VASE] Le joueur est dans le trigger et a appuyé sur E");

            PlayerInventory inventory = other.GetComponent<PlayerInventory>();
            if (inventory == null)
            {
                Debug.LogError("[VASE] Pas de PlayerInventory trouvé sur le joueur !");
                return;
            }

            Debug.Log("[VASE] Inventaire actuel contient " + inventory.items.Count + " objets");

            if (inventory.items.Count > 0)
            {
                GameObject prefabToPlace = inventory.items[0];

                if (prefabToPlace == null)
                {
                    Debug.LogError("[VASE] L'objet récupéré de l'inventaire est NULL !");
                    return;
                }

                Debug.Log("[VASE] Tentative d'instancier : " + prefabToPlace.name);

                // On enlève du sac
                inventory.RemoveItem(prefabToPlace);

                // Sécurité : vérifie encore que le prefab est pas null
                if (prefabToPlace != null)
                {
                    Instantiate(prefabToPlace, spawnPoint.position, spawnPoint.rotation, spawnPoint);
                    Debug.Log("[VASE] Objet instancié avec succès dans le vase !");
                }
                else
                {
                    Debug.LogError("[VASE] prefabToPlace est NULL au moment d'Instantiate !");
                }

                isFilled = true;

                if (ritualManager != null)
                {
                    ritualManager.CheckRitual();
                }
                else
                {
                    Debug.LogWarning("[VASE] Pas de RitualManager assigné !");
                }
            }
            else
            {
                Debug.LogWarning("[VASE] Inventaire vide, aucun objet à placer !");
            }
        }
    }
}
