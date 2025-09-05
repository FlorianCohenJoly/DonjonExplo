using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public DoorManager doorManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Assure-toi que ton joueur a bien le tag "Player"
        {
            doorManager.HasKeyDoor();
        }
    }
}
