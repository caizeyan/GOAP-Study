using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GWorld 
{
 
    
    private static GWorld instance;
    //private GWorldStates states;
    private Dictionary<string, int> states;
    private Queue<GameObject> patinets;
    private Queue<GameObject> cubicles;
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
        patinets = new Queue<GameObject>();
        cubicles = new Queue<GameObject>();
        var cubs = GameObject.FindGameObjectsWithTag("Cubicle");
        for (int i = 0; i < cubs.Length; i++)
        {
            cubicles.Enqueue(cubs[i]);
        }
        ModifyState(CreateHelper.State(StateType.CubicleNum,cubs.Length));
    }

    public Dictionary<string, int> GetStates()
    {
        return states;
    }

    public void AddPatient(GameObject go)
    {
        patinets.Enqueue(go);
        ModifyState(CreateHelper.State(StateType.PatientNum,1));        
    }
    
    public GameObject GetPatient()
    {
        if (patinets.Count == 0)
        {
            return null;
        }
        var go = patinets.Peek();
        patinets.Dequeue();
        ModifyState(CreateHelper.State(StateType.PatientNum,-1));
        return go;
    }

    
    public void AddCubicle(GameObject go)
    {
        cubicles.Enqueue(go);
        ModifyState(CreateHelper.State(StateType.CubicleNum,1));        
    }
    
    public GameObject GetCubicle()
    {
        if (cubicles.Count == 0)
        {
            return null;
        }
        var go = cubicles.Peek();
        cubicles.Dequeue();
        ModifyState(CreateHelper.State(StateType.CubicleNum,-1));
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
