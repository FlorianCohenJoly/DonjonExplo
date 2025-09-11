using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public int money = 0;
    public TMP_Text moneyText; // référence vers un Text dans la scène

    public AudioClip moneySound;

    void Start()
    {
        UpdateUI();
    }

    public void AddMoney(int amount)
    {
        money += amount;
        UpdateUI();
        PlaySound();
    }

    void UpdateUI()
    {
        if (moneyText != null)
            moneyText.text = "Money: " + money.ToString();
    }

    public void PlaySound()
    {
        if (moneySound != null)
        {
            AudioSource.PlayClipAtPoint(moneySound, Camera.main.transform.position);
        }
    }



}
