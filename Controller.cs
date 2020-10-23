using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private Controls controls;

    public Input input;

    private void Awake()
    {
        controls = new Controls();
        controls.Fighter.Move.performed += context => input.direction = context.ReadValue<Vector2>();
        controls.Fighter.LightAttack.started += context => input.light.pressed = true;
        controls.Fighter.LightAttack.canceled += context => input.light.canceled = true;
        controls.Fighter.HeavyAttack.started += context => input.heavy.pressed = true;
        controls.Fighter.HeavyAttack.canceled += context => input.heavy.canceled = true;
        controls.Fighter.SpecialAttack.started += context => input.special.pressed = true;
        controls.Fighter.SpecialAttack.canceled += context => input.special.canceled = true;
    }

    private void Update()
    {
        input.light.UpdateButton();
        input.heavy.UpdateButton();
        input.special.UpdateButton();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    public struct Input
    {
        public Vector2 direction;

        public Button light;
        public Button heavy;
        public Button special;

        public struct Button
        {
            public bool pressed;
            public bool held;
            public bool canceled;

            public void UpdateButton()
            {
                if (!held)
                    canceled = false;
                if (canceled)
                    held = false;
                if (held)
                    pressed = false;
                if (pressed)
                    held = true;
            }
        }
    }
}
