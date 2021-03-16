using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchingState : State
{
    SteerableBehaviour steerable;

    public override void Awake()
    {
        base.Awake();

        Transition attacking = new Transition();
        attacking.condition = new ConditionClose(transform, GameObject.FindWithTag("player").transform, 20.0f);
        attacking.target = GetComponent<AttackingState>();
        transitions.Add(attacking);

        steerable = GetComponent<SteerableBehaviour>();
    }

    float angle = 0;
    public override void Update()
    {
        angle += 0.1f * Time.deltaTime;
        Mathf.Clamp(angle, 0.0f, 2.0f * Mathf.PI);
        float x = Mathf.Sin(angle);
        float y = Mathf.Cos(angle);

        steerable.Thrust(y, y);
    }
}
