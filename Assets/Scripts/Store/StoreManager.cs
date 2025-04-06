using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public enum DayOfTheWeek { Monday, Tuesday, Wednesday, Thursday, Friday };

public class StoreManager : MonoBehaviour
{
    public StoreData store;
    public GameObject ShopUI;
    public ShopManager shop;
    public Cart cart;
    private int dayCounter;
    private int hourCounter = 8;
    private int minuteCounter = 0;

    void Start()
    {
        store = new StoreData(100, 50);
        Debug.Log("Money: " + store.Money + ", Reputation: " + store.Reputation);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            store.AddMoney(500f);
        }
    }


    public void MakeSale(int saleValue)
    {
        store.AddMoney(saleValue);
        store.IncreaseReputation(1);
    }

    public void Refund(int refundValue)
    {
        store.SpendMoney(refundValue);
        store.DecreaseReputation(1);
    }
    public void PurchaseItems()
    {
        store.SpendMoney(cart.finalPrice);
        ShopUI.SetActive(false);
    }

}

