using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopButtons : MonoBehaviour
{
    public GameObject itemForSale;
    public TextMeshProUGUI price;
    public TextMeshProUGUI quantity;
    public Button upArrow;
    public Button downArrow;
    public ShopManager shop;

    void Start()
    {
        itemForSale = GetComponent<GameObject>();
        price = GetComponent<TextMeshProUGUI>();
        quantity = GetComponent<TextMeshProUGUI>();
        upArrow = GetComponent<Button>();   
        downArrow = GetComponent<Button>();
        shop = GetComponent<ShopManager>();

        if (itemForSale != null)
            if (price != null)
                if (quantity != null)
                    if (upArrow != null)
                        if (downArrow != null)
                            if (shop != null)
                                Debug.Log("Shop UI set up!");
    }


}
