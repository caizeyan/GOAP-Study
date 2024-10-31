using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WorldState
{
    public string key;
    public int value;
}

public class GWorldStates
{
    private Dictionary<string, int> states;

    public GWorldStates()
    {
        states = new Dictionary<string, int>();
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

    public Dictionary<string, int> GetStatus()
    {
        return states;
    }

}
