using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerInteraction : MonoBehaviour
{
    public GameObject currentHeldItem;
    public GameObject currentSelectedStation;
    Collider[] objs;

    public GameObject heldItemPos;
    public GameObject interactPos;
    public float interactRadius;

    public LayerMask ignore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        objs = Physics.OverlapSphere(interactPos.transform.position, interactRadius, ~ignore);
        if(objs.Length == 0)
        {
            currentSelectedStation = null;
            return;
        }

        foreach(Collider c in objs)
        {
            if((c.tag == "foodCrate" || c.tag == "counter" || c.tag == "dishRack" || c.tag == "stove" || c.tag == "cuttingBoard") && (currentSelectedStation == null || currentSelectedStation != c.gameObject))
            {
                currentSelectedStation = c.gameObject;
            }
        }
    }

    void checkTag(GameObject temp)
    {
        if (temp == null)
            return;

        switch(temp.tag)
        {
            case "lettuceStack":
                GameObject newObj = temp.GetComponent<ingredientStack>().getFromStack();
                currentHeldItem = newObj;
                currentHeldItem.transform.position = heldItemPos.transform.position;
                currentHeldItem.transform.parent = gameObject.transform;
                break;
            case "tomatoStack":

                break;
            case "cheeseStack":

                break;
        }
        
    }

    public void interactWithStation(InputAction.CallbackContext context)
    {
        if(context.started && !context.performed)
        {
            if (currentSelectedStation.tag == "cuttingBoard" && currentHeldItem == null)
            {
                GameObject temp = currentSelectedStation.GetComponent<CuttingBoard>().getItem();
                checkTag(temp);
            }
            if (currentSelectedStation.tag == "counter")
            {

            }
        }
        if(context.performed)
        {
            if(currentSelectedStation.tag == "cuttingBoard")
            {
                currentSelectedStation.GetComponent<CuttingBoard>().setChopping(true);
            }
        }
        if(context.canceled)
        {
            if (currentSelectedStation.tag == "cuttingBoard")
            {
                currentSelectedStation.GetComponent<CuttingBoard>().setChopping(false);
            }
        }
    }

    public void pickupItem(InputAction.CallbackContext context)
    {
        if (currentSelectedStation == null)
            return;
        if(currentSelectedStation.tag == "foodCrate")
            if (currentHeldItem != null && currentSelectedStation != null && currentSelectedStation.GetComponent<FoodSpawner>().checkMax())
                return;
        if(currentSelectedStation.tag == "counter")
        {
            if (currentHeldItem != null && currentSelectedStation.GetComponent<Counter>().checkItem())
                return;
        }
        if (currentSelectedStation.tag == "dishRack")
            if (currentHeldItem != null && currentSelectedStation != null && currentSelectedStation.GetComponent<DishRack>().checkMax())
                return;

        if (currentSelectedStation.tag == "foodCrate")
        {
            var station = currentSelectedStation.GetComponent<FoodSpawner>();
            if (currentHeldItem != null)
            {
                
                GameObject leftover = station.pickupItem(gameObject, true, currentHeldItem, false, false);
                if (leftover == null)
                {
                    currentHeldItem = null;
                }
            }
            else
            {
                GameObject pickedUp = station.pickupItem(gameObject, false, null, false, false);
                if (pickedUp != null)
                {
                    currentHeldItem = pickedUp;
                    currentHeldItem.transform.position = heldItemPos.transform.position;
                    currentHeldItem.transform.parent = gameObject.transform;
                }
            }
        }
        else if (currentSelectedStation.tag == "cuttingBoard")
        {
            var station = currentSelectedStation.GetComponent<CuttingBoard>();
            if (currentHeldItem != null)
            {
                //GameObject tempobj;
                if (currentHeldItem.tag == "cheeseSlice" || currentHeldItem.tag == "lettuceSlice" || currentHeldItem.tag == "tomatoSlice")
                {
                    station.pickupItem(gameObject, true, currentHeldItem, false, true);
                    //removeHeldItem();
                }
                if(currentHeldItem.tag == "cheeseStack" || currentHeldItem.tag == "lettuceStack" || currentHeldItem.tag == "tomatoStack")
                {
                    station.pickupItem(gameObject, true, currentHeldItem, true, false);
                }


                GameObject leftover = station.pickupItem(gameObject, true, currentHeldItem, false, false);
                if (leftover == null)
                {
                    currentHeldItem = null;
                }
            }
            else
            {
                GameObject pickedUp = station.pickupItem(gameObject, false, null, false, false);
                if (pickedUp != null)
                {
                    currentHeldItem = pickedUp;
                    currentHeldItem.transform.position = heldItemPos.transform.position;
                    currentHeldItem.transform.parent = gameObject.transform;
                }
            }
        }
        else if(currentSelectedStation.tag == "stove")
        {
            var station = currentSelectedStation.GetComponent<Stove>();
            if (currentHeldItem != null)
            {
                GameObject leftover = station.pickupItem(gameObject, true, currentHeldItem, false, false);
                if (leftover == null)
                {
                    currentHeldItem = null;
                }
            }
            else
            {
                GameObject pickedUp = station.pickupItem(gameObject, false, null, false, false);
                if (pickedUp != null)
                {
                    currentHeldItem = pickedUp;
                    currentHeldItem.transform.position = heldItemPos.transform.position;
                    currentHeldItem.transform.parent = gameObject.transform;
                }
            }
        }
        else if (currentSelectedStation.tag == "dishRack")
        {
            var station = currentSelectedStation.GetComponent<DishRack>();
            if (currentHeldItem != null)
            {
                GameObject leftover = station.pickupItem(gameObject, true, currentHeldItem, false, false);
                if (leftover == null)
                {
                    currentHeldItem = null;
                }
            }
            else
            {
                GameObject pickedUp = station.pickupItem(gameObject, false, null, false, false);
                if (pickedUp != null)
                {
                    currentHeldItem = pickedUp;
                    currentHeldItem.transform.position = heldItemPos.transform.position;
                    currentHeldItem.transform.parent = gameObject.transform;
                }
            }
        }
        else if(currentSelectedStation.tag == "counter")
        {
            var station = currentSelectedStation.GetComponent<Counter>();
            if(currentHeldItem != null)
            {
                GameObject leftover = station.pickupItem(gameObject, true, currentHeldItem, false, false);
                if (leftover == null)
                {
                    currentHeldItem = null;
                }
            }
            else
            {
                GameObject pickedUp = station.pickupItem(gameObject, false, null, false, false);
                if (pickedUp != null)
                {
                    currentHeldItem = pickedUp;
                    currentHeldItem.transform.position = heldItemPos.transform.position;
                    currentHeldItem.transform.parent = gameObject.transform;
                }
            }
        }
            

        
    }


    public GameObject setHeldItem(GameObject item)
    {
        currentHeldItem = item;
        return item;
    }

    public GameObject removeHeldItem()
    {
        return currentHeldItem;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(interactPos.transform.position, interactRadius);
    }
}
