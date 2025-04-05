using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    private List<GameObject> itemsInCart;
    public ShopButtons button;
    private StoreData store;
    private int total;
    public int tax;
    public GameObject shopUI;

    void Start()
    {
        store = GetComponent<StoreData>();

        if (store == null)
        {
            Debug.Log("Could not access store data");
        }
    }

    public void IncreaseQuantity ()
    {
        button.quantity++;        
    }

    public void DecreaseQuantity()
    {
        button.quantity--;
    }

    public void AddToCart()
    {

    }

    public void purchaseCart()
    {
        store.SpendMoney(total);
    }

    public void Exit()
    {
        shopUI.SetActive(false);
    }
    public int GetTotal()
    {
        return 0;
    }
}
