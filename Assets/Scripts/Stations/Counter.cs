using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour, IInteractable
{

    public GameObject currentItem;

    public Transform spawnLocation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool checkItem()
    {
        if (currentItem == null)
            return false;
        else
            return true;
    }


    public GameObject pickupItem(GameObject player, bool hasFood, GameObject item)
    {
        if (item != null && currentItem == null)
        {
            currentItem = item;
            currentItem.transform.parent = spawnLocation;
            currentItem.transform.localPosition = Vector3.zero;
            player.GetComponent<playerInteraction>().removeHeldItem();
            return null;
        }
        else if (item == null && currentItem != null)
        {
            GameObject temp = currentItem;
            currentItem = null;
            return temp;
        }
        else
        {
            Debug.Log("Error in Interact in food Spawner");
            return null;
        }
    }

    public void Interact(GameObject player)
    {

    }



}
