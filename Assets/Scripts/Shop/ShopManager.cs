using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public Cart cart;
    public GameObject shopUI;

    public List<ShopItem> shopItems;

    private int itemCount = 0;
    private float total = 0;
    public float tax = 0;


    void Start()
    {
        if (shopUI == null)
        {
            shopUI = this.gameObject;
        }

        ShopItem item1 = shopItems[0];
        ShopItem item2 = shopItems[1];
        ShopItem item3 = shopItems[2];
        ShopItem item4 = shopItems[3];
        ShopItem item5 = shopItems[4];
        ShopItem item6 = shopItems[5];
        ShopItem item7 = shopItems[6];
        ShopItem item8 = shopItems[7];

    }

    void Update()
    {
        cart.UpdateCart(itemCount);
    }

    public void IncreaseQuantity(ShopItem item)
    {
        if (item != null)
        {
            item.quantity++;
            itemCount++;
        }
        else
        {
            Debug.LogWarning("Item is null in IncreaseQuantity.");
        }
    }

    public void DecreaseQuantity(ShopItem item)
    {
        if (item != null && item.quantity > 0)
        {
            item.quantity--;
            itemCount--;
        }
        else
        {
            Debug.LogWarning("Item is null or quantity is 0 in DecreaseQuantity.");
        }
    }


    public void Exit()
    {
        if (shopUI != null)
            shopUI.SetActive(false);
        else
            Debug.LogWarning("Shop UI not set!");
    }
}
