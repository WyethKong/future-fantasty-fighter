using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using States;

[RequireComponent(typeof(Controller))]
public class Fighter<T> : MonoBehaviour
{
    public Controller controller { get; private set; }
    public StateMachine<T> stateMachine { get; private set; }

    private Meter health;
    // Must have : health, ex, (for attacks?)hitbox, (for attacks?)hurtbox, etc.

    public virtual void Awake()
    {
        controller = GetComponent<Controller>();
        stateMachine = new StateMachine<T>();
    }

    public virtual void Update()
    {
        stateMachine.UpdateState();
    }

    public struct Meter
    {
        public int max;
        public int min;
        public int current
        {
            get
            {
                return current;
            }

            set
            {
                current = value;
                if (current > max)
                {
                    current = max;
                }
                if (current < min)
                {
                    current = min;
                }
            }
        }
    }
}
