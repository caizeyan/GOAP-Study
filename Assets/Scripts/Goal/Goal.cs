using System.Collections.Generic;
using UnityEngine;

public class Goal
{
        public Dictionary<string, int> sgoals;
        public bool remove;
        public string name;
        
        public Goal(string name)
        { 
                sgoals = new Dictionary<string, int>(); 
                remove = false;
                this.name = name;
        }

        public void AddStation(StateType type)
        {
             AddStation(CreateHelper.State(type));
        }
        public void AddStation(StateType type,int value)
        { 
                AddStation(CreateHelper.State(type,value));
        }
        
        public void AddStation(WorldState state)
        { 
                AddStation(state.key,state.value);
        }

        public void AddStation(string key, int value)
        {
                if (sgoals.ContainsKey(key))
                {
                        Debug.LogError("重复加载");
                        return;
                }
                sgoals.Add(key,value);
        }
}
