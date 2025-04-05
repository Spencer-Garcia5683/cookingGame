using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour, IInteractable
{
    public GameObject shop;
    public ShopManager shopManager;
    void Start()
    {
        shopManager = GetComponent<ShopManager>();

        if (shopManager == null)
        {
            Debug.Log("No Shop Manager Active");
        }

        shop = GetComponent<GameObject>();

        if (shop == null)
        {
            Debug.Log("No shop attached");
        }
       
    }

    public void Interact()
    {
        shop.SetActive(true);
    }
}
