using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StoreManager : MonoBehaviour
{
    public StoreData store;

    void Start()
    {
        store = new StoreData(100, 50); // starting values
        Debug.Log("Money: " + store.Money + ", Reputation: " + store.Reputation);
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
}

