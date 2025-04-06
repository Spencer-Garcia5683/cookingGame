using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour, IInteractable
{
    public GameObject shopUI;
    public ShopManager shopManager;
    void Start()
    {
        shopManager = GetComponent<ShopManager>();

        if (shopManager == null)
        {
            Debug.Log("No Shop Manager Active");
        }

        shopUI = GetComponent<GameObject>();

       
    }

    public void Interact(GameObject player)
    {
        shopUI.SetActive(true);
    }

    public GameObject pickupItem(GameObject player, bool tempBool, GameObject item, bool isStack, bool isSlice, bool isPlate)
    {
        return null;
    }
}
