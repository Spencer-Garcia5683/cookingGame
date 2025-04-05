using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopButtons : MonoBehaviour
{
    public GameObject itemForSale;
    public TextMeshProUGUI priceTXT;
    public TextMeshProUGUI quantityTXT;
    public Button upArrow;
    public Button downArrow;
    public ShopManager shop;

    public float price;
    public int quantity; 

    void Start()
    {
        priceTXT = GetComponent<TextMeshProUGUI>();
        quantityTXT = GetComponent<TextMeshProUGUI>();
        shop = GetComponent<ShopManager>();

    }

    void Update()
    {
        quantityTXT.text = quantity.ToString();
        priceTXT.text = "$" + price.ToString();
    }


}
