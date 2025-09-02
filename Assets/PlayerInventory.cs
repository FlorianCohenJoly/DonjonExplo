using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<GameObject> items = new List<GameObject>();

    public void AddItem(GameObject prefab)
    {
        if (prefab == null)
        {
            Debug.LogError("[INVENTAIRE] Tentative d'ajouter un prefab NULL !");
            return;
        }

        items.Add(prefab);
        Debug.Log("[INVENTAIRE] Objet ajouté: " + prefab.name + " | Total = " + items.Count);
    }

    public void RemoveItem(GameObject prefab)
    {
        if (prefab == null)
        {
            Debug.LogError("[INVENTAIRE] Tentative de retirer un prefab NULL !");
            return;
        }

        if (items.Contains(prefab))
        {
            items.Remove(prefab);
            Debug.Log("[INVENTAIRE] Objet retiré: " + prefab.name + " | Total = " + items.Count);
        }
        else
        {
            Debug.LogWarning("[INVENTAIRE] Impossible de retirer " + prefab.name + " car il n'est pas dans l'inventaire !");
        }
    }
}
