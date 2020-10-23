using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace States
{
    public class StateMachine<T>
    {
        private State<T> stateCurrent;

        public void ChangeState(State<T> newState)
        {
            if(stateCurrent != null)
                stateCurrent.Exit();
            stateCurrent = newState;
            stateCurrent.Enter();
        }

        public void UpdateState()
        {
            if(stateCurrent != null)
                stateCurrent.Update();
        }
    }

    public abstract class State<T>
    {
        public abstract void Enter();

        public abstract void Update();

        public abstract void Exit();
    }
}