using UnityEngine;

public class ShopTicket : MonoBehaviour
{
    [Header("UI RPGTalk")]
    public GameObject rpgTalkDonneObjet;   // Dialogue quand achat possible
    public GameObject rpgTalkPrendArgent;  // Dialogue quand argent insuffisant

    [Header("Objet à acheter")]
    public GameObject objetBuy;
    public int price = 5;

    private MoneyManager moneyManager;

    private void Start()
    {
        moneyManager = FindObjectOfType<MoneyManager>();
        if (moneyManager == null)
        {
            Debug.LogError("MoneyManager non trouvé !");
        }
    }

 
    public bool HasEnoughMoney()
    {
        if (moneyManager == null) return false;

        if (moneyManager.money >= price)
        {
            // Dialogue achat possible
            rpgTalkDonneObjet.SetActive(true);
            rpgTalkPrendArgent.SetActive(false);
            return true;
        }
        else
        {
            // Dialogue pas assez d’argent
            rpgTalkPrendArgent.SetActive(true);
            rpgTalkDonneObjet.SetActive(false);
            return false;
        }
    }
    public void Buy()
    {
        if (HasEnoughMoney())
        {
            moneyManager.AddMoney(-price);
            PlayerInventory.Instance.AddItem(objetBuy);

            Debug.Log($"Achat effectué : {objetBuy.name} pour {price} !");
        }
    }
}
