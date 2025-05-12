using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModeController : MonoBehaviour
{
    [Header("Customer System")]
    public GameObject customerPrefab;
    public List<Transform> spawnPoints;
    public List<Transform> lineSpots; // Line positions (in order)
    public List<Transform> tableSpots; // Spots where customers eat
    public float spawnInterval = 10f;
    public int maxCustomers = 5;

    private List<customer> customerQueue = new List<customer>();
    private int currentCustomers = 0;

    private void Start()
    {
        StartCoroutine(SpawnCustomerRoutine());
    }

    IEnumerator SpawnCustomerRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            if (currentCustomers < maxCustomers && customerQueue.Count < lineSpots.Count)
            {
                SpawnCustomer();
            }
        }
    }

    void SpawnCustomer()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Count);
        int queueIndex = customerQueue.Count;

        GameObject newCustomerObj = Instantiate(customerPrefab, spawnPoints[spawnIndex].position, Quaternion.identity);
        customer newCustomer = newCustomerObj.GetComponent<customer>();
        newCustomer.Initialize(lineSpots[queueIndex], this, queueIndex);
        customerQueue.Add(newCustomer);

        currentCustomers++;
    }

    public void ServeNextCustomer()
    {
        if (customerQueue.Count == 0)
            return;

        customer served = customerQueue[0];
        customerQueue.RemoveAt(0);

        Transform table = FindAvailableTable();
        if (table != null)
        {
            served.MoveTo(table);
            served.state = CustomerState.WalkingToTable;
        }
        else
        {
            // If no table is available, hold customer at line end or idle
            Debug.LogWarning("No available tables.");
        }

        // Move the rest of the queue forward
        for (int i = 0; i < customerQueue.Count; i++)
        {
            customerQueue[i].AdvanceInLine(lineSpots[i], i);
        }

        currentCustomers--; // Optional depending on how you define "current"
    }

    // New method to remove a customer from the line
    public void RemoveCustomerFromLine(customer customerToRemove)
    {
        // Remove the customer from the queue
        customerQueue.Remove(customerToRemove);

        // Shift the remaining customers forward
        for (int i = 0; i < customerQueue.Count; i++)
        {
            customerQueue[i].AdvanceInLine(lineSpots[i], i); // Update their line position
        }

        currentCustomers--; // Decrease the current customer count
    }

    Transform FindAvailableTable()
    {
        foreach (Transform t in tableSpots)
        {
            TableSpot tableSpot = t.GetComponent<TableSpot>();
            if (!tableSpot.isOccupied)
            {
                tableSpot.isOccupied = true;
                return t;
            }
        }
        return null;
    }

    public void OnCustomerLeaveTable(Transform table)
    {
        TableSpot spot = table.GetComponent<TableSpot>();
        if (spot != null)
        {
            spot.isOccupied = false;
        }
    }
}
