using UnityEngine;

public class FoodSpawner : MonoBehaviour, IInteractable
{
    public GameObject foodPrefab;
    public FoodItem availableFoods;

    void Start()
    {
        
    }

    void Update()
    {
                 
    }

    public void SpawnFood(FoodItem itemToSpawn)
    {
        GameObject food = Instantiate(foodPrefab, transform.position, Quaternion.identity);
        FoodObject foodObj = food.GetComponent<FoodObject>();
        foodObj.foodData = itemToSpawn;
    }

    public void Interact()
    {
        SpawnFood(availableFoods);
    }
}
