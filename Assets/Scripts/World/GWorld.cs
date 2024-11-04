using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GWorld 
{
 
    
    private static GWorld instance;
    //private GWorldStates states;
    private Dictionary<string, int> states;

    public static GWorld Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GWorld();
            }

            return instance;
        }
    }

    private GWorld()
    {
        states = new Dictionary<string, int>();
    }

    public Dictionary<string, int> GetStates()
    {
        return states;
    }

    public void ModifyState(string key, int value)
    {
        if (states.ContainsKey(key))
        {
            states[key] += value;
        }
        else
        {
            states.Add(key, value);
        }
    }

    public void SetState(string key, int value)
    {
        if (states.ContainsKey(key))
        {
            states[key] = value;
        }
        else
        {
            states.Add(key, value);
        }
    }

    public bool IsConditionSatisfied(WorldState condition)
    {
        return Helper.IsConditionSatisfied(states, condition);
    }
}
