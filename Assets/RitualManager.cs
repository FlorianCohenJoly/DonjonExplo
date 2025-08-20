using UnityEngine;

public class RitualManager : MonoBehaviour
{
    public Vase[] vases;

    public void CheckRitual()
    {
        foreach (Vase vase in vases)
        {
            if (!vase.isFilled) return; // Un vase est encore vide
        }

        Debug.Log("✨ Rituel complété ! ✨");
        TriggerRitual();
    }

    void TriggerRitual()
    {
        // Ici tu choisis ce qui se passe quand les 4 vases sont remplis
        // Exemple : ouvrir une porte, faire apparaître un boss, lancer un effet de lumière
    }
}
