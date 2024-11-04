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
