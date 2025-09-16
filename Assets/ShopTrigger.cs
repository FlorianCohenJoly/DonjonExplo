using UnityEngine;

public class ShopTrigger : MonoBehaviour
{
    public ShopTicket shopTicket;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            shopTicket.HasEnoughMoney();
        }
    }
}
