using System.Collections;
using System.Collections.Generic;
using static System.Diagnostics.Debug;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
public enum Events { Earthquake, Thunderstorm }

public class RandomEvents : MonoBehaviour
{
    public GameObject camerashake;
    private PlayerMovement movement;

    void Start()
    {
        if (movement == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
                movement = player.GetComponent<PlayerMovement>();
        }
    }


    // Called externally when a new day starts
    public void OnNewDay()
    {
        TriggerEvent(Events.Earthquake);
        /*int roll = Random.Range(1, 11); // 1 to 10 inclusive
        Debug.Log("Event roll: " + roll);

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
        }*/
    }

    private void TriggerEvent(Events e)
    {
        switch (e)
        {
            case Events.Earthquake:
                Debug.Log("Earthquake event triggered!");
                StartCoroutine(earthquake());
                break;
            case Events.Thunderstorm:
                Debug.Log("Thunderstorm event triggered!");
                //Instantiate(camerashake);
                break;
        }
    }

    private IEnumerator earthquake()
    {
        int shake = Random.Range(1, 11);
        int seconds = Random.Range(20, 55);

        Debug.Log("Number of shakes: " + shake);

        for (int i = 0; i < shake; i++)
        {
            Instantiate(camerashake);
            if (movement != null)
                movement.moveSpeed *= 0.5f;

            yield return new WaitForSeconds(3f);

            if (movement != null)
                movement.moveSpeed *= 2f;
        }

        yield return new WaitForSeconds(seconds);
    }

}
