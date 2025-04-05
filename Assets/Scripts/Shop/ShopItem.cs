using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShopItem
{
    public string itemName;
    public int price;
    public GameObject image;

    public ShopItem(string itemName, int price, GameObject image)
    {
        this.itemName = itemName;
        this.price = price;
        this.image = image;
    }
}

