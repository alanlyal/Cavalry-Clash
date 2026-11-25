
using UnityEngine;
using UnityEngine.AI;

namespace Core.FSM
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class InvadingPawnStateMachine : MonoBehaviour
    {
        [SerializeField] private Transform castle;
        private StateMachine stateMachine;
        public int DamageResit = 1;
        private void Awake()
        {
            castle = GameObject.FindWithTag("Castle").transform;
            stateMachine = new StateMachine();
            MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
            NavMeshAgent agent = GetComponent<NavMeshAgent>();
            InvadingState invadeState = new InvadingState(meshRenderer, agent, castle);
            stateMachine.SetState(invadeState);
        }
        public int NodeIndex;
        public void Update()
        {
            stateMachine.Update();
        }
        private void OnEnable()
        {
            GameLoopManager.CurrentEnemies.Add(this);
        }
        private void OnDisable()
        {
            GameLoopManager.CurrentEnemies.Remove(this);
        }
    }
}
    
