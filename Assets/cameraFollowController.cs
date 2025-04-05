using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollowController : MonoBehaviour
{
    public Transform player1;
    public Transform player2;

    public Vector3 offsetDirection = new Vector3(0f, 5f, -8f);
    public float smoothTime = 0.3f;

    public float minDistance = 8f;   // Closest the camera gets
    public float maxDistance = 20f;  // Furthest the camera pulls back
    public float zoomLimiter = 10f;  // How fast the zoom reacts

    private Vector3 velocity;

    void Start()
    {
        offsetDirection = offsetDirection.normalized;
    }

    void Update()
    {
        if (player2 == null)
        {
            GameObject p2 = GameObject.FindGameObjectWithTag("Player2");
            if (p2 != null)
                player2 = p2.transform;
        }
    }

    void FixedUpdate()
    {
        if (player1 == null)
            return;

        MoveCamera();
    }

    void MoveCamera()
    {
        Vector3 centerPoint = GetCenterPoint();
        float distance = GetPlayerDistance();

        float dynamicDistance = Mathf.Clamp(distance, 0f, zoomLimiter);
        float currentZoom = Mathf.Lerp(minDistance, maxDistance, dynamicDistance / zoomLimiter);

        Vector3 targetPosition = centerPoint + offsetDirection * currentZoom;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        transform.LookAt(centerPoint);
    }

    Vector3 GetCenterPoint()
    {
        if (player2 != null)
        {
            return (player1.position + player2.position) / 2f;
        }
        return player1.position;
    }

    float GetPlayerDistance()
    {
        if (player2 != null)
        {
            return Vector3.Distance(player1.position, player2.position);
        }
        return 0f;
    }
}
