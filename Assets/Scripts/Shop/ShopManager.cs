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
        
    }

    public void DecreaseQuantity()
    {

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

    }
}
