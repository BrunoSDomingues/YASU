using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingState : State
{
    SteerableBehaviour steerable;
    IShooter shooter;

    public override void Awake()
    {
        base.Awake();

        Transition searching = new Transition();
        searching.condition = new ConditionFar(transform, GameObject.FindWithTag("player").transform, 20.0f);
        searching.target = GetComponent<SearchingState>();
        transitions.Add(searching);

        steerable = GetComponent<SteerableBehaviour>();
        shooter = steerable as IShooter;
        if (shooter == null)
        {
            throw new MissingComponentException("This GameObject does not implement IShooter");
        }
    }

    private float shootDelay = 0.5f;
    private float _lastShootTimestamp = 0.0f;
    public override void Update()
    {
        if (Time.time - _lastShootTimestamp < shootDelay) return;
        _lastShootTimestamp = Time.time;
        shooter.Shoot();
    }
}
