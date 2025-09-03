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

    // fonction qui verifie si l'inventaire contient une keyDoor
    public void HasKeyDoor()
    {
        foreach (GameObject item in items)
        {
            if (item.CompareTag("KeyDoor"))
            {
                Debug.Log("[INVENTAIRE] Le joueur possède une clé de porte.");
                return;
            }
        }
        Debug.Log("[INVENTAIRE] Le joueur ne possède pas de clé de porte.");
    }
}
