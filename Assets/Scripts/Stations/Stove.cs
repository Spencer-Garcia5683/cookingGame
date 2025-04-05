using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stove : MonoBehaviour, IInteractable
{
    public int MAXFOOD = 4;
    public GameObject cookedPattyPrefab;
    public GameObject[] stoveTops;
    public Vector3[] spawnPositions;
    public int selectedIndex = 0;
    public int topIndex = -1;

    bool burner1Bool = false;
    public float cookTime = 5f;

    void Start()
    {
        stoveTops = new GameObject[MAXFOOD];
    }

    void Update()
    {
        if (stoveTops[0] != null && stoveTops[0].tag == "patty")
        {
            StartCoroutine(burner1());
        }
        else
            StopCoroutine(burner1());
    }

    IEnumerator burner1()
    {

        if (burner1Bool)
            yield break;

        burner1Bool = true;

        yield return new WaitForSeconds(cookTime);
        if (stoveTops[0] != null)
        {
            GameObject temp = stoveTops[0];
            stoveTops[0] = Instantiate(cookedPattyPrefab, spawnPositions[0], Quaternion.identity);
            stoveTops[0].transform.parent = gameObject.transform;
            stoveTops[0].transform.localPosition = spawnPositions[0];
            Destroy(temp);
        }
        burner1Bool = false;
        yield break;
    }

    public void Interact(GameObject player)
    {
        selectedIndex = selectedIndex++ % MAXFOOD;
    }

    GameObject placeFood(GameObject food)
    {
        if (topIndex + 1 > MAXFOOD - 1)
            return food;

        topIndex++;
        stoveTops[selectedIndex] = food;
        stoveTops[selectedIndex].transform.parent = gameObject.transform;
        stoveTops[selectedIndex].transform.localPosition = spawnPositions[topIndex];

        return null;
    }

    public GameObject takeFood()
    {
        if (topIndex < 0)
            return null;

        GameObject temp = stoveTops[selectedIndex];
        stoveTops[selectedIndex] = null;
        topIndex--;
        return temp;
    }

    // This is called when a player interacts with the object
    public GameObject pickupItem(GameObject player, bool hasFood, GameObject item)
    {
        if (item != null)
        {
            placeFood(item);
            player.GetComponent<playerInteraction>().removeHeldItem();
            return null;
        }
        else if (item == null)
        {
            return takeFood();
        }
        else
        {
            Debug.Log("Error in Interact in food Spawner");
            return null;
        }
    }

    public bool checkMax()
    {
        if (topIndex == MAXFOOD - 1)
            return true;
        else
            return false;
    }
}
