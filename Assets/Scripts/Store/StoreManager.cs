using System.Collections;
using System.Collections.Generic;
using static System.Diagnostics.Debug;
using TMPro;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;


public enum DayOfTheWeek { Monday, Tuesday, Wednesday, Thursday, Friday };

public class StoreManager : MonoBehaviour
{
    public StoreData store;
    public GameObject ShopUI;
    public ShopManager shop;
    public Cart cart;

    public TextMeshProUGUI minutes;
    public TextMeshProUGUI hours;

    private int dayCounter;
    private int hourCounter = 8;
    private int minuteCounter = 0;

    void Start()
    {
        store = new StoreData(100, 50);
        Debug.Log("Money: " + store.Money + ", Reputation: " + store.Reputation);

        StartCoroutine(UpdateTime());

        if (minutes == null) minutes = GetComponent<TextMeshProUGUI>();
        if (hours == null) hours = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (minutes != null)
            if (minuteCounter < 10)
            {
                minutes.text = ":0" + minuteCounter.ToString();
            }
            else
            {
                minutes.text = ":" + minuteCounter.ToString();
            }

        if (hours != null) hours.text = hourCounter.ToString();
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

    private IEnumerator UpdateTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f); // wait 1 second

            minuteCounter++;

            if (minuteCounter >= 60)
            {
                minuteCounter = 0;
                hourCounter++;

                // You can also add logic to reset hours if needed (e.g., 24hr cycle)
                if (hourCounter >= 12)
                {
                    hourCounter = 0;
                    dayCounter++;
                    Debug.Log("New Day! Day count: " + dayCounter);

                    StopCoroutine(UpdateTime());
                }
            }

            //Debug.Log($"Time: {hourCounter:D2}:{minuteCounter:D2}");
        }
    }


}

