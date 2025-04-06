using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishRack : MonoBehaviour, IInteractable
{
    public int MAXPLATES = 4;
    public GameObject platePrefab;
    public GameObject[] allPlates;
    public Vector3[] spawnPositions;
    public int topIndex = -1;

    // Start is called before the first frame update
    void Start()
    {
        allPlates = new GameObject[MAXPLATES];
        InitializePlates();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool checkMax()
    {
        if (topIndex == MAXPLATES - 1)
            return true;
        else
            return false;
    }

    void InitializePlates()
    {
        for (int i = 0; i < MAXPLATES; i++)
        {
            SpawnPlates(i);
        }
    }

    // Spawns food only if the spot is empty
    public void SpawnPlates(int index)
    {
        if (index >= spawnPositions.Length)
        {
            Debug.LogWarning("Spawn index out of bounds!");
            return;
        }

        if (allPlates[index] != null)
            return;

        GameObject plate = Instantiate(platePrefab, gameObject.transform.position + spawnPositions[index], Quaternion.identity);
        allPlates[index] = plate;
        topIndex++;
    }

    GameObject placePlate(GameObject plate)
    {
        if (topIndex + 1 > MAXPLATES - 1)
            return plate;

        topIndex++;
        allPlates[topIndex] = plate;
        allPlates[topIndex].transform.parent = gameObject.transform;
        allPlates[topIndex].transform.localPosition = spawnPositions[topIndex];

        return null;
    }

    public GameObject takePlate()
    {
        if (topIndex < 0)
            return null;

        GameObject temp = allPlates[topIndex];
        allPlates[topIndex] = null;
        topIndex--;
        return temp;
    }


    public GameObject pickupItem(GameObject player, bool hasFood, GameObject item, bool isStack, bool isSlice, bool isPlate)
    {
        if (item != null)
        {
            placePlate(item);
            player.GetComponent<playerInteraction>().removeHeldItem();
            return null;
        }
        else if (item == null)
        {
            return takePlate();
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
