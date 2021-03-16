using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionFar : Condition
{
    Transform agent;
    Transform target;
    float minDist;

    public ConditionFar(Transform ag, Transform ta, float dist)
    {
        agent = ag;
        target = ta;
        minDist = dist;
    }

    public override bool Test()
    {
        return Vector2.Distance(agent.position, target.position) >= minDist;
    }
}
