using UnityEngine;

public class FoodSpawner : MonoBehaviour, IInteractable
{
    public int MAXFOOD = 6;
    public GameObject foodPrefab;
    public GameObject[] availableFoods;
    public Vector3[] spawnPositions;
    public int topIndex = -1;

    void Start()
    {
        availableFoods = new GameObject[MAXFOOD];
        InitializeFood();
    }

    // Called once at the start to fill all spawn spots
    void InitializeFood()
    {
        for (int i = 0; i < MAXFOOD; i++)
        {
            SpawnFood(i);
        }
    }

    // Spawns food only if the spot is empty
    public void SpawnFood(int index)
    {
        if (index >= spawnPositions.Length)
        {
            Debug.LogWarning("Spawn index out of bounds!");
            return;
        }

        if (availableFoods[index] != null)
            return;

        GameObject food = Instantiate(foodPrefab, gameObject.transform.position + spawnPositions[index], Quaternion.identity);
        availableFoods[index] = food;
        topIndex++;
    }

    GameObject placeFood(GameObject food)
    {
        if (topIndex + 1 > MAXFOOD - 1)
            return food;

        topIndex++;
        availableFoods[topIndex] = food;
        availableFoods[topIndex].transform.parent = gameObject.transform;
        availableFoods[topIndex].transform.localPosition = spawnPositions[topIndex];
        
        return null;
    }

    public GameObject takeFood()
    {
        if (topIndex < 0)
            return null;

        GameObject temp = availableFoods[topIndex];
        availableFoods[topIndex] = null;
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
}
