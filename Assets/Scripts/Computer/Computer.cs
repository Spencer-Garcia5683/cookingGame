using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour, IInteractable
{
    public GameObject shopUI;
    public ShopManager shopManager;
    void Start()
    {
        if (shopManager == null)
        {
            shopManager = GetComponent<ShopManager>();
        }

        shopUI = GetComponent<GameObject>();

       
    }

    public void Interact(GameObject player)
    {
        if (shopUI != null)
        {
            shopUI.SetActive(true);
        }
    }

    public GameObject pickupItem(GameObject player, bool tempBool, GameObject item, bool isStack, bool isSlice, bool isPlate)
    {
        return null;
    }
}
