using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StoreData
{
    public int Money { get; private set; }
    public int Reputation { get; private set; }

    public StoreData(int startingMoney, int startingReputation)
    {
        Money = startingMoney;
        Reputation = startingReputation;
    }

    public void AddMoney(int amount)
    {
        Money += amount;
    }

    public void SpendMoney(int amount)
    {
        Money = Mathf.Max(0, Money - amount); // Prevent negative money
    }

    public void IncreaseReputation(int amount)
    {
        Reputation += amount;
    }

    public void DecreaseReputation(int amount)
    {
        Reputation = Mathf.Max(0, Reputation - amount); // Prevent negative reputation
    }

    public void ResetData()
    {
        Money = 0;
        Reputation = 0;
    }
}
