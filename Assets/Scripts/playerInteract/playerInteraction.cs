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
            if(c.tag == "foodCrate" && (currentSelectedStation == null || currentSelectedStation != c.gameObject))
            {
                currentSelectedStation = c.gameObject;
            }
        }
    }

    public void pickupItem(InputAction.CallbackContext context)
    {
        if (currentSelectedStation == null)
            return;

        var foodSpawner = currentSelectedStation.GetComponent<FoodSpawner>();

        if (currentHeldItem != null)
        {
            GameObject leftover = foodSpawner.pickupItem(gameObject, true, currentHeldItem);
            if (leftover == null)
            {
                currentHeldItem = null;
            }
        }
        else
        {
            GameObject pickedUp = foodSpawner.pickupItem(gameObject, false, null);
            if (pickedUp != null)
            {
                currentHeldItem = pickedUp;
                currentHeldItem.transform.position = heldItemPos.transform.position;
                currentHeldItem.transform.parent = gameObject.transform;
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
