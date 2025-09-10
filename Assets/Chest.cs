using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{

    public GameObject chestTop;

    public void OpenChest()
    {
        chestTop.transform.localRotation = Quaternion.Euler(-70, 0f, 0f);
    }



}
