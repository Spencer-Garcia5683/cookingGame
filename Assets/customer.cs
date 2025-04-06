using UnityEngine;
using UnityEngine.AI;

public class customer : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform targetSpot;
    private GameModeController controller;
    private int lineIndex;

    public CustomerState state;

    public void Initialize(Transform destination, GameModeController gameController, int linePos)
    {
        agent = GetComponent<NavMeshAgent>();
        controller = gameController;
        lineIndex = linePos;

        MoveTo(destination);
        state = CustomerState.WalkingToLine;
    }

    private void Update()
    {
        switch (state)
        {
            case CustomerState.WalkingToLine:
                if (HasReachedDestination())
                    state = CustomerState.WaitingInLine;
                break;

            case CustomerState.Ordering:
                // tell GameMode or Player script they’re ordering
                break;

            case CustomerState.WaitingForFood:
                // Wait here
                break;

            case CustomerState.WalkingToTable:
                if (HasReachedDestination())
                    state = CustomerState.Eating;
                break;

            case CustomerState.Eating:
                // Timer or animation here, then leave
                break;
        }
    }

    public void MoveTo(Transform newTarget)
    {
        targetSpot = newTarget;
        agent.SetDestination(newTarget.position);
    }

    public bool HasReachedDestination()
    {
        return !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance;
    }

    public void AdvanceInLine(Transform nextSpot, int newIndex)
    {
        lineIndex = newIndex;
        MoveTo(nextSpot);
        state = CustomerState.WalkingToLine;
    }

    public int GetLineIndex() => lineIndex;
}

public enum CustomerState
{
    WalkingToLine,
    WaitingInLine,
    Ordering,
    WaitingForFood,
    WalkingToTable,
    Eating
}

