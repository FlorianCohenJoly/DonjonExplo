using System.Collections;
using UnityEngine;

public class PortalTP : MonoBehaviour
{
    [Header("Portail de destination")]
    public PortalTP targetPortal;       // Lien vers le script de l'autre portail
    public Transform targetPosition;    // Point précis où le joueur arrive

    public CharacterController isControleur;

    [Header("Paramètres")]
    public float teleportDelay = 0.5f;

    private bool isTeleporting = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!isTeleporting && other.CompareTag("Player"))
        {
            StartCoroutine(TeleportPlayer(other));
        }
    }

    private IEnumerator TeleportPlayer(Collider player)
    {
        isTeleporting = true;

        // Si un point de sortie existe → on s’en sert
        if (targetPosition != null)
        {
            isControleur.enabled = false; 
            player.transform.position = targetPosition.position;
            player.transform.rotation = targetPosition.rotation; 
            isControleur.enabled = true; 


        }
        /*  else if (targetPortal != null && targetPortal.targetPosition != null)
          {
              player.transform.position = targetPortal.targetPosition.position;
              player.transform.rotation = targetPortal.targetPosition.rotation;
          }*/

        // On active aussi le flag du portail cible pour éviter la boucle infinie
        if (targetPortal != null)
        {
            targetPortal.isTeleporting = true;
            yield return new WaitForSeconds(teleportDelay);
            targetPortal.isTeleporting = false;
        }

        yield return new WaitForSeconds(teleportDelay);
        isTeleporting = false;
    }
}
