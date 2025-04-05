using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private StoreManager storeManager;  // Reference to StoreManager
    [SerializeField] private ShopItem[] shopItems;      // Array of shop items

    // This method returns the list of shop items to be used by other classes (e.g., ShopButton)
    public ShopItem[] GetShopItems()
    {
        return shopItems;
    }

    void Start()
    {

    }

    public void BuyItem(ShopItem item)
    {
        if (storeManager.store.Money >= item.price)
        {
            storeManager.store.SpendMoney(item.price);
            Debug.Log($"Bought {item.itemName} for ${item.price}. Remaining money: {storeManager.store.Money}");
        }
        else
        {
            Debug.Log("Not enough money to buy this item.");
        }
    }
}
