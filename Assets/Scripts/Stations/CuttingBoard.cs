using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CuttingBoard : MonoBehaviour, IInteractable
{
    public GameObject currentItem;

    public Transform spawnLocation;
    public float chopTime = 3f;
    bool chopping = false;
    bool startChopping = false;

    public GameObject lettuceStack, tomatoStack, cheeseStack;

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
        //StartCoroutine(chopFood());
    }

    public void setChopping(bool choice)
    {
        startChopping = choice;
        if(startChopping)
            StartCoroutine(chopFood());
        else
            StopCoroutine(chopFood());
    }

    IEnumerator chopFood()
    {
        if (chopping)
            yield break;

        chopping = true;
        GameObject temp = currentItem;
        print("Chopping is running");
        yield return new WaitForSeconds(chopTime);
        

        switch(temp.tag)
        {
            case "lettuce":
                currentItem = Instantiate(lettuceStack, spawnLocation.position, Quaternion.identity);
                currentItem.transform.parent = gameObject.transform;
                //currentItem.transform.localPosition = spawnLocation.position;
                break;

            case "tomato":
                currentItem = Instantiate(tomatoStack, spawnLocation.position, Quaternion.identity);
                currentItem.transform.parent = gameObject.transform;
                break;

            case "cheese":
                currentItem = Instantiate(cheeseStack, spawnLocation.position, Quaternion.identity);
                currentItem.transform.parent = gameObject.transform;
                break;
        }
        //currentItem.transform.parent = spawnLocation;
        //currentItem.transform.localPosition = Vector3.zero;
        Destroy(temp);
        chopping = false;
        yield break;
    }
}
