using System.Collections.Generic;

public class Goal
{
        public Dictionary<string, int> sgoals;
        public bool remove;

        public Goal()
        { 
                sgoals = new Dictionary<string, int>(); 
                remove = false;
        }
}
