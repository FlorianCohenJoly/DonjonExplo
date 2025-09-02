using UnityEngine;

public class RitualManager : MonoBehaviour
{
    public Vase[] vases;

    public void CheckRitual()
    {
        foreach (Vase vase in vases)
        {
            if (!vase.isFilled) return;
        }

        Debug.Log("✨ Rituel complété ! ✨");
        TriggerRitual();
    }

    void TriggerRitual()
    {
        // todo 
    }
}
