using Assets.Scripts.Runtime.Interface;
using UnityEngine;

namespace Abstraction
{
    public abstract class StateMachine
    {
        protected IState currentState;

        public void ChangeState(IState newState)
        {
            currentState?.Exit();

            currentState = newState;

            currentState.Enter();
        }

        public void HandleInput()
        {
            currentState?.HandleInput();
        }

        public void Update()
        {
            currentState?.Update();
        }

        public void PhysicsUpdate()
        {
            currentState?.PhysicsUpdate();
        }

        public void OntriggerEnter(Collider coll) { currentState?.OntriggerEnter(coll); }
        public void OntriggerExit(Collider coll) { currentState?.OntriggerExit(coll); }
    }
}
