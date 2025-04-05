using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    private ShopManager shopManager;
    private ShopItem shopItem;

    void Start()
    {
        shopManager = FindObjectOfType<ShopManager>();
        GetComponent<Button>().onClick.AddListener(OnButtonClicked);
    }

    public void SetUpButton(ShopItem item)
    {
        shopItem = item;

        GetComponentInChildren<Text>().text = shopItem.itemName;
    }

    void OnButtonClicked()
    {
        // Call BuyItem on the ShopManager
        if (shopItem != null)
        {
            shopManager.BuyItem(shopItem);
        }
    }
}
