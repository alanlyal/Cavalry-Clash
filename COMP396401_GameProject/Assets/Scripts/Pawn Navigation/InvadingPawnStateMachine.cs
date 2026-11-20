using UnityEngine;
using UnityEngine.AI;

namespace Core.FSM
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class InvadingPawnStateMachine : MonoBehaviour
    {
        [SerializeField] private Transform castle;
        private StateMachine stateMachine;
        private void Awake()
        {
            castle = GameObject.FindWithTag("Castle").transform;
            stateMachine = new StateMachine();
            MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
            NavMeshAgent agent = GetComponent<NavMeshAgent>();
            InvadingState invadeState = new InvadingState(meshRenderer, agent, castle);
            stateMachine.SetState(invadeState);
        }
        public void Update()
        {
            stateMachine.Update();
        }
    }
}
    
