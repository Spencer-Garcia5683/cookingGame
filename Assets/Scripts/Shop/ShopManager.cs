using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public Cart cart;
    public GameObject shopUI;
    public GameObject checkOutUI;
    public TextMeshProUGUI TotalTXT;

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


        if (TotalTXT == null) TotalTXT = GetComponent<TextMeshProUGUI>();

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

    public void OpenCheckOut()
    {
        shopUI.SetActive(false);
        checkOutUI.SetActive(true);
        SetupCheckout();
    }

    public void Back()
    {
        checkOutUI.SetActive(false);
        shopUI.SetActive(true);
    }

    private void SetupCheckout()
    {

    }

    private float GetTotal()
    {
        float total = 0f;

        foreach (ShopItem item in shopItems)
        {
            if (item.quantity > 0)
            {
                total += item.price * item.quantity;
            }
            else
            {
                item.priceTXT.text = "";
                item.quantityTXT.text = "";
                item.nameTXT.text = "";
                item.itemImageUI = null;
            }
        }

        return total;
    }

    
}
