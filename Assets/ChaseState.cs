using UnityEngine;
using UnityEngine.AI;

public class ChaseState : State
{
    private NavMeshAgent agent;
    private Transform player;

    public ChaseState(GameObject owner, Transform player) : base(owner)
    {
        this.agent = owner.GetComponent<NavMeshAgent>();
        this.player = player;
    }

    public override void Enter()
    {
        Debug.Log("Entering Chase State");
    }

    public override void Execute()
    {
        if (player != null)
        {
            agent.destination = player.position;
        }
    }

    public override void Exit()
    {
        Debug.Log("Exiting Chase State");
        agent.ResetPath();
    }
}
