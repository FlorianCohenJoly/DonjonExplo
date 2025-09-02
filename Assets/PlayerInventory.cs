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
        }

    }
}
