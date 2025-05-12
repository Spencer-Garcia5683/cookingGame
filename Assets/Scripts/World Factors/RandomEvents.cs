using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Events { Earthquake, Thunderstorm }

public class RandomEvents : MonoBehaviour
{
    public GameObject camerashake;
    private PlayerMovement movement;

    public float minEventInterval = 10f;  // Minimum time interval between events
    public float maxEventInterval = 30f;  // Maximum time interval between events

    void Start()
    {
        if (movement == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
                movement = player.GetComponent<PlayerMovement>();
        }

        // Start the random event coroutine that triggers events at random intervals
        StartCoroutine(RandomEventRoutine());
    }

    // Coroutine that triggers events at random intervals
    private IEnumerator RandomEventRoutine()
    {
        while (true)  // Loop indefinitely
        {
            float waitTime = Random.Range(minEventInterval, maxEventInterval);
            yield return new WaitForSeconds(waitTime);

            // Roll a random number to determine which event to trigger
            int roll = Random.Range(1, 11);  // 1 to 10 inclusive

            switch (roll)
            {
                case 1:
                    TriggerEvent(Events.Earthquake);
                    break;
                case 2:
                    TriggerEvent(Events.Thunderstorm);
                    break;
                default:
                    Debug.Log("Normal day - no special event.");
                    break;
            }
        }
    }

    private void TriggerEvent(Events e)
    {
        switch (e)
        {
            case Events.Earthquake:
                Debug.Log("Earthquake event triggered!");
                StartCoroutine(EarthquakeEffect());
                break;
            case Events.Thunderstorm:
                Debug.Log("Thunderstorm event triggered!");
                // Instantiate the camerashake or thunderstorm effect here if needed
                break;
        }
    }

    private IEnumerator EarthquakeEffect()
    {
        int shakeCount = Random.Range(1, 11);  // Number of shakes
        int seconds = Random.Range(20, 55);    // Duration of the event

        Debug.Log("Number of shakes: " + shakeCount);

        for (int i = 0; i < shakeCount; i++)
        {
            Instantiate(camerashake);  // Assuming camerashake is a prefab to be instantiated
            if (movement != null)
                movement.moveSpeed *= 0.5f;

            yield return new WaitForSeconds(3f);

            if (movement != null)
                movement.moveSpeed *= 2f;
        }

        yield return new WaitForSeconds(seconds);
    }
}
