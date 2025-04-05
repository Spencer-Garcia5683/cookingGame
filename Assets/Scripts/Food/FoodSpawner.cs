using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject foodPrefab;
    public FoodItem availableFood;

    void Start()
    {
        
    }

    void Update()
    {
        //if("Interact") {
        //  SpawnFood(availableFoods);
        //}  
    }

    public void SpawnFood(FoodItem itemToSpawn)
    {
        GameObject food = Instantiate(foodPrefab, transform.position, Quaternion.identity);
        FoodObject foodObj = food.GetComponent<FoodObject>();
        foodObj.foodData = itemToSpawn;
    }
}
