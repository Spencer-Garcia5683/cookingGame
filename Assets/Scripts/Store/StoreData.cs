using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StoreData
{
    public float Money { get; private set; }
    public int Reputation { get; private set; }

    public StoreData(float startingMoney, int startingReputation)
    {
        Money = startingMoney;
        Reputation = startingReputation;
    }

    public void AddMoney(float amount)
    {
        Money += amount;
    }

    public void SpendMoney(float amount)
    {
        if (Money > amount)
        {
            Money = Mathf.Max(0, Money - amount);
        }
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
        Money = 0.0f;
        Reputation = 0;
    }
}
