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
            if((c.tag == "foodCrate" || c.tag == "counter" || c.tag == "dishRack" || c.tag == "stove" || c.tag == "cuttingBoard" || c.tag == "computer" || c.tag == "serve" || c.tag == "trash") && (currentSelectedStation == null || currentSelectedStation != c.gameObject))
            {
                currentSelectedStation = c.gameObject;
            }
        }
    }

    void checkTag(GameObject temp)
    {
        if (temp == null)
            return;

        GameObject newObj;
        switch (temp.tag)
        {
            case "lettuceStack":
                newObj = temp.GetComponent<ingredientStack>().getFromStack();
                currentHeldItem = newObj;
                currentHeldItem.transform.position = heldItemPos.transform.position;
                currentHeldItem.transform.parent = gameObject.transform;
                break;
            case "tomatoStack":
                newObj = temp.GetComponent<ingredientStack>().getFromStack();
                currentHeldItem = newObj;
                currentHeldItem.transform.position = heldItemPos.transform.position;
                currentHeldItem.transform.parent = gameObject.transform;
                break;
            case "cheeseStack":
                newObj = temp.GetComponent<ingredientStack>().getFromStack();
                currentHeldItem = newObj;
                currentHeldItem.transform.position = heldItemPos.transform.position;
                currentHeldItem.transform.parent = gameObject.transform;
                break;
        }
        
    }

    private float buttonPressTime;
    [SerializeField] private float holdThreshold = 0.2f; // Adjust as needed

    public void interactWithStation(InputAction.CallbackContext context)
    {
        if(currentSelectedStation == null) return;

        if (context.started)
        {
            // Start the timer when the button is first pressed
            buttonPressTime = Time.time;

            // Optionally begin chopping immediately (visually responsive)
            if (currentSelectedStation.tag == "cuttingBoard")
            {
                currentSelectedStation.GetComponent<CuttingBoard>().setChopping(true);
            }
            if(currentSelectedStation.tag == "computer")
            {
                currentSelectedStation.GetComponent<Computer>().Interact(gameObject);
            }
        }

        if (context.canceled)
        {
            // End of input — check how long the button was held
            float pressDuration = Time.time - buttonPressTime;

            if (pressDuration < holdThreshold)
            {
                // Tapped (quick press) behavior
                if (currentSelectedStation.tag == "cuttingBoard" && currentHeldItem == null)
                {
                    GameObject temp = currentSelectedStation.GetComponent<CuttingBoard>().getItem();
                    
                    checkTag(temp);
                    if (temp.GetComponent<ingredientStack>().ingredients[0] == null)
                        currentSelectedStation.GetComponent<CuttingBoard>().removeItem();
                }
                else if (currentSelectedStation.tag == "counter" && currentHeldItem == null)
                {
                    GameObject temp = currentSelectedStation.GetComponent<Counter>().getItem();
                    
                    checkTag(temp);
                    if (temp.GetComponent<ingredientStack>().ingredients[0] == null)
                        temp.GetComponent<Counter>().removeItem();
                }
            }

            // Regardless of tap or hold, cancel chopping
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
            {
                return;
            }
        }
        if (currentSelectedStation.tag == "dishRack")
            if (currentHeldItem != null && currentSelectedStation != null && currentSelectedStation.GetComponent<DishRack>().checkMax())
                return;
        

        if(currentSelectedStation.tag == "trash")
        {
            var station = currentSelectedStation.GetComponent<trash>();
            if (currentHeldItem != null)
                station.pickupItem(gameObject, true, currentHeldItem, false, false, false);
        }

        if (currentSelectedStation.tag == "foodCrate")
        {
            var station = currentSelectedStation.GetComponent<FoodSpawner>();
            if (currentHeldItem != null)
            {
                
                GameObject leftover = station.pickupItem(gameObject, true, currentHeldItem, false, false, false);
                if (leftover == null)
                {
                    currentHeldItem = null;
                }
            }
            else
            {
                GameObject pickedUp = station.pickupItem(gameObject, false, null, false, false, false);
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
                    station.pickupItem(gameObject, true, currentHeldItem, false, false, false);
                    //removeHeldItem();
                }
                if(currentHeldItem.tag == "cheeseStack" || currentHeldItem.tag == "lettuceStack" || currentHeldItem.tag == "tomatoStack")
                {
                    station.pickupItem(gameObject, true, currentHeldItem, true, false, false);
                }


                GameObject leftover = station.pickupItem(gameObject, true, currentHeldItem, false, false, false);
                if (leftover == null)
                {
                    currentHeldItem = null;
                }
            }
            else
            {
                GameObject pickedUp = station.pickupItem(gameObject, false, null, false, false, false);
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
                GameObject leftover = station.pickupItem(gameObject, true, currentHeldItem, false, false, false);
                if (leftover == null)
                {
                    currentHeldItem = null;
                }
            }
            else
            {
                GameObject pickedUp = station.pickupItem(gameObject, false, null, false, false, false);
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
                GameObject leftover = station.pickupItem(gameObject, true, currentHeldItem, false, false, false);
                if (leftover == null)
                {
                    currentHeldItem = null;
                }
            }
            else
            {
                GameObject pickedUp = station.pickupItem(gameObject, false, null, false, false, false);
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
                GameObject leftover;
                //if(currentHeldItem.tag == "plate")
                //if (currentSelectedStation.GetComponent<Counter>().currentItem != null)
                    //if (currentSelectedStation.GetComponent<Counter>().currentItem.tag == "plate")
                    //{
                        //leftover = station.pickupItem(gameObject, true, currentHeldItem, false, false, );
                        //return;
                    //}

                leftover = station.pickupItem(gameObject, true, currentHeldItem, false, false, false);
                if (leftover == null)
                {
                    currentHeldItem = null;
                }
            }
            else
            {
                GameObject pickedUp = station.pickupItem(gameObject, false, null, false, false, false);
                if (pickedUp != null)
                {
                    currentHeldItem = pickedUp;
                    currentHeldItem.transform.position = heldItemPos.transform.position;
                    currentHeldItem.transform.parent = gameObject.transform;
                }
            }
        }
        else if (currentSelectedStation.tag == "serve")
        {
            var station = currentSelectedStation.GetComponent<servingWindow>();
            if (currentHeldItem != null)
            {
                GameObject leftover;
                //if(currentHeldItem.tag == "plate")
                //if (currentSelectedStation.GetComponent<Counter>().currentItem != null)
                //if (currentSelectedStation.GetComponent<Counter>().currentItem.tag == "plate")
                //{
                //leftover = station.pickupItem(gameObject, true, currentHeldItem, false, false, );
                //return;
                //}

                leftover = station.pickupItem(gameObject, true, currentHeldItem, false, false, false);
                if (leftover == null)
                {
                    currentHeldItem = null;
                }
            }
            else
            {
                GameObject pickedUp = station.pickupItem(gameObject, false, null, false, false, false);
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

    public void DestroyItem()
    {
        Destroy(currentHeldItem);
        currentHeldItem = null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(interactPos.transform.position, interactRadius);
    }
}
