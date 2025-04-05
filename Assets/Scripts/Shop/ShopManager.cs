using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private StoreManager storeManager;
    [SerializeField] private ShopItem[] shopItems;

    public void BuyItem(ShopItem item)
    {
        
        if (storeManager.store.Money >= item.price)
        {
            storeManager.store.SpendMoney(item.price);
        }
        else
        {
            Debug.Log("Not enough money to buy this item.");
        }
    }
}
