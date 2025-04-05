using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StoreUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private TextMeshProUGUI reputationText;
    [SerializeField] private StoreManager storeManager;

    [SerializeField] private Image backgroundImage;

    [SerializeField] private float padding = 10f; // Padding around the text

    void Update()
    {
        if (storeManager != null && storeManager.store != null)
        {
            // Update money and reputation text
            moneyText.text = $"Money: ${storeManager.store.Money}";
            reputationText.text = $"Reputation: {storeManager.store.Reputation}";
        }
    }

}
