using TMPro;
using UnityEngine;
using UnityEngine.UI; // Needed for Image

[System.Serializable]
public class ShopItem : MonoBehaviour
{
    public string itemName;
    public Sprite itemImage;
    public float price;
    public int quantity;

    public TextMeshProUGUI priceTXT;
    public TextMeshProUGUI quantityTXT;
    public TextMeshProUGUI nameTXT;
    public Image itemImageUI; // UI component to show the sprite

    void Start()
    {
        // Assign components if not already assigned in inspector
        if (priceTXT == null) priceTXT = GetComponent<TextMeshProUGUI>();
        if (quantityTXT == null) quantityTXT = GetComponent<TextMeshProUGUI>();
        if (nameTXT == null) nameTXT = GetComponent<TextMeshProUGUI>();
        if (itemImageUI == null) itemImageUI = GetComponentInChildren<Image>(); 
    }

    void Update()
    {
        if (priceTXT != null) priceTXT.text = "$" + price.ToString("F2");
        if (quantityTXT != null) quantityTXT.text = quantity.ToString();
        if (nameTXT != null) nameTXT.text = itemName;
        if (itemImageUI != null && itemImage != null) itemImageUI.sprite = itemImage;
    }
}
