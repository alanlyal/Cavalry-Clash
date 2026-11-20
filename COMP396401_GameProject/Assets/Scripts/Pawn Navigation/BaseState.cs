using UnityEngine;
using UnityEngine.AI;

namespace Core.FSM
{
    public abstract class BaseState : IState
    {

        protected MeshRenderer meshRenderer;

        protected Collider sensor; ///something enters trigger NPC reacts - changes state from default to different one
        protected NavMeshAgent agent;


        protected BaseState(MeshRenderer renderer, NavMeshAgent agent)
        {
            meshRenderer = renderer;
            this.agent = agent;
        }


        public virtual void Enter()
        {

        }

        public virtual void Exit()
        {
            agent.ResetPath();
        }
        public virtual void Update()
        {

        }



    }


}