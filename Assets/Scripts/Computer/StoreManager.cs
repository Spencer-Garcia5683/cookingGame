using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StoreManager : MonoBehaviour
{
    public StoreData store;

    void Start()
    {
        store = new StoreData(100, 50); 
        Debug.Log("Money: " + store.Money + ", Reputation: " + store.Reputation);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton4))
        {
            store.AddMoney(100);
        }
        if (Input.GetKeyUp(KeyCode.P))
        {
            store.IncreaseReputation(10);
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
}

