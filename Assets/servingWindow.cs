using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class servingWindow : MonoBehaviour, IInteractable
{

    public GameObject burgSlot;
    public GameObject iceCreamSlot;

    public Transform spawnLocation;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool HasCorrectPlateForCustomer(customer c)
    {
        if (c.desiredFood == FoodType.Burger && burgSlot.transform.childCount > 0)
            return true;

        if (c.desiredFood == FoodType.IceCream && iceCreamSlot.transform.childCount > 0)
            return true;

        return false;
    }

    public GameObject pickupItem(GameObject player, bool hasFood, GameObject item, bool isStack, bool isSlice, bool isPlate)
    {
        if (item != null && burgSlot == null)
        {
            burgSlot = item;
            burgSlot.transform.parent = spawnLocation;
            burgSlot.transform.localPosition = Vector3.zero;
            player.GetComponent<playerInteraction>().removeHeldItem();
            return null;
        }
        else if (item == null && burgSlot != null)
        {
            GameObject temp = burgSlot;
            burgSlot = null;
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

    public void removeItem()
    {
        Destroy(burgSlot);
        burgSlot = null;
    }

}
