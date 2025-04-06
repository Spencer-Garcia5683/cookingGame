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
        return null;
    }
    public void Interact(GameObject player)
    {

    }

}
