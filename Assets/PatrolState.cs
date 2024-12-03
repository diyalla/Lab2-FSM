using UnityEngine;
using UnityEngine.AI;

public class PatrolState : State
{
    private NavMeshAgent agent;
    private Transform[] waypoints;
    private int currentWaypointIndex;

    public PatrolState(GameObject owner, Transform[] waypoints) : base(owner)
    {
        this.agent = owner.GetComponent<NavMeshAgent>();
        this.waypoints = waypoints;
        this.currentWaypointIndex = 0;
    }

    public override void Enter()
    {
        MoveToNextWaypoint();
    }

    public override void Execute()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            MoveToNextWaypoint();
        }
    }

    public override void Exit()
    {
        agent.ResetPath();
    }

    private void MoveToNextWaypoint()
    {
        if (waypoints.Length == 0) return;

        agent.destination = waypoints[currentWaypointIndex].position;
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
    }
}
