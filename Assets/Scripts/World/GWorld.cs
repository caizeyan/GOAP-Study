using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GWorld 
{
 
    
    private static GWorld instance;
    //private GWorldStates states;
    private Dictionary<string, int> states;
    private List<GameObject> patinets;
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
        patinets = new List<GameObject>();
    }

    public Dictionary<string, int> GetStates()
    {
        return states;
    }

    public void AddPatient(GameObject go)
    {
        patinets.Add(go);
        ModifyState(CreateHelper.State(StateType.PatientNum,1));        
    }
    
    public GameObject GetPatient()
    {
        if (patinets.Count == 0)
        {
            return null;
        }
        var go = patinets[0];
        patinets.RemoveAt(0);
        ModifyState(CreateHelper.State(StateType.PatientNum,-1));
        return go;
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

        if (states[key] == 0)
        {
            states.Remove(key);
        }
    }
    
    public void ModifyState(WorldState state)
    {
        ModifyState(state.key,state.value);
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
