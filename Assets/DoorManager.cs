using JetBrains.Annotations;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    // Cible pour la porte de droite
    public Transform rightDoor;
    // Cible pour la porte de gauche
    public Transform leftDoor;
    // Vitesse de rotation des portes
    public float rotationSpeed = 2f;

    private bool areDoorsOpen = false;
    private Quaternion rightDoorStartRotation;
    private Quaternion leftDoorStartRotation;
    private Quaternion rightDoorTargetRotation;
    private Quaternion leftDoorTargetRotation;

    public GameObject rpgTalkWithoutKey;

    public GameObject rpgTalkWithKey;



    void Start()
    {
        // On enregistre les rotations initiales
        if (rightDoor != null)
        {
            rightDoorStartRotation = rightDoor.rotation;
        }
        if (leftDoor != null)
        {
            leftDoorStartRotation = leftDoor.rotation;
        }

        // On calcule les rotations cibles
        rightDoorTargetRotation = Quaternion.Euler(rightDoorStartRotation.eulerAngles.x, rightDoorStartRotation.eulerAngles.y + 70f, rightDoorStartRotation.eulerAngles.z);
        leftDoorTargetRotation = Quaternion.Euler(leftDoorStartRotation.eulerAngles.x, leftDoorStartRotation.eulerAngles.y - 70f, leftDoorStartRotation.eulerAngles.z);
    }

    void Update()
    {

        if (areDoorsOpen)
        {

            if (rightDoor != null)
            {
                rightDoor.rotation = Quaternion.Slerp(rightDoor.rotation, rightDoorTargetRotation, Time.deltaTime * rotationSpeed);
            }

            if (leftDoor != null)
            {
                leftDoor.rotation = Quaternion.Slerp(leftDoor.rotation, leftDoorTargetRotation, Time.deltaTime * rotationSpeed);
            }
        }

        /*    // Exemple : Appuyer sur la barre d'espace pour ouvrir les portes
           if (Input.GetKeyDown(KeyCode.Space))
           {
               areDoorsOpen = !areDoorsOpen; // Inverse l'état des portes (ouvert/fermé)
           } */
    }

    public void OpenDoors()
    {
        areDoorsOpen = true;
    }

    // fonction qui verifie si l'inventaire contient une keyDoor 
    public bool HasKeyDoor()
    {
        foreach (var item in PlayerInventory.Instance.items)
        {
            if (item != null && item.CompareTag("KeyDoor"))
            {
                rpgTalkWithKey.SetActive(true);
                rpgTalkWithoutKey.SetActive(false);
                return true;

            }
        }
        rpgTalkWithoutKey.SetActive(true);
        rpgTalkWithKey.SetActive(false);
        return false;
    }
}