using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IAction 
{
    public float cost = 1f;
    public WorldState[] preCondition;
    public WorldState[] afterEffect;
    private GWorld world =  GWorld.Instance;
    private bool isRuning = false;
    public bool IsValuable()
    {
        return IsValuable(world.GetStates());
    }
    public bool IsValuable(Dictionary<string, int> dictionary)
    {
        if (preCondition != null)
        {
            //判断前提条件
            foreach (var condition in preCondition)
            {
                if (!world.IsConditionSatisfied(condition))
                {
                    return false;
                }
            }
        }
        return true;
    }
    
}
