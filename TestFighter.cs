using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFighter : Fighter<TestFighter>
{
    // Changed code!!!
    public override void Awake()
    {
        base.Awake();
        Debug.Log("We changed this thing");
    }

    public override void Update()
    {
        base.Update();
    }
}
