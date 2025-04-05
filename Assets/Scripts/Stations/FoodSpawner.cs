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
        Vector3 position = new Vector3 (transform.position.x, transform.position.y + 0.2f, transform.position.z);
        GameObject food = Instantiate(foodPrefab, position, Quaternion.identity);
        FoodObject foodObj = food.GetComponent<FoodObject>();
        foodObj.foodData = itemToSpawn;
    }

    public void Interact()
    {
        SpawnFood(availableFoods);
    }
}
