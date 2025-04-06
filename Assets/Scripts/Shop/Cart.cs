using TMPro;
using UnityEngine;

public class Cart : MonoBehaviour
{
    private ShopManager shop;
    public TextMeshProUGUI numItemsTXT;
    public TextMeshProUGUI totalPriceTXT;
    private int numItems;
    public float finalPrice;


    void Update()
    {
        if (numItemsTXT != null)
        {
            numItemsTXT.text = numItems.ToString();
        }
        if (totalPriceTXT != null)
        {
            totalPriceTXT.text = "Total: $" + finalPrice.ToString("F2");
        }
    }

    public void UpdateCart(int newTotal)
    {
        numItems = newTotal;
    }

    // Update the price displayed in the cart
    public void UpdatePrice(float newPrice)
    {
        finalPrice = newPrice;
    }

}
