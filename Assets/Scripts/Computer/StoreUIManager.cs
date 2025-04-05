using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoreUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private TextMeshProUGUI reputationText;
    [SerializeField] private StoreManager storeManager;

    void Update()
    {
        if (storeManager != null && storeManager.store != null)
        {
            moneyText.text = $"Money: ${storeManager.store.Money}";
            reputationText.text = $"Reputation: {storeManager.store.Reputation}";
        }
    }
}
