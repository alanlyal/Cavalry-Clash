using Core.FSM;
using UnityEngine;
using UnityEngine.AI;

public class InvadingState : BaseState
{
    private Transform castle;
    public InvadingState(MeshRenderer renderer, NavMeshAgent agent, Transform castle) : base(renderer, agent)
    {
        this.castle = castle;
    }
    public override void Enter()
    {
        meshRenderer.material.color = Color.red;

        Debug.Log("castle Position:" + castle.position);

        if (castle == null || !agent.isOnNavMesh)
        {
            Debug.Log("Castle is missing or agent is not on nav mesh");
            return;
        }

        agent.SetDestination(castle.position);
        Debug.Log("Agent Destination: " + agent.destination);
    }
    public override void Update()
    {
        
    }

    public override void Exit()
    {
        base.Exit(); ///required to stop agent from moving / to end state fully
    }
}
