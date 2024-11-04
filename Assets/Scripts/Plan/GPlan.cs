using System.Collections.Generic;
using UnityEngine;

public class Node{
    public Node parent;
    public float cost;
    public IAction action;
    public Dictionary<string, int> states;

    public Node(Node parent, float cost, IAction action, Dictionary<string, int> states)
    {
        this.parent = parent;
        this.cost = cost;
        this.action = action;
        this.states = new Dictionary<string, int>(states);
    }

}


public class GPlan
{
    public Stack<IAction> GetPlan(List<IAction> actions, Dictionary<string, int> goal)
    {
        List<IAction> usableAction = new List<IAction>();
        foreach (var action in actions)
        {
            if (action.IsValuable())
            {
                usableAction.Add(action);
            }
        }

        List<Node> leaves = new List<Node>();
        Node start = new Node(null, 0, null, GWorld.Instance.GetStates());
        bool success = BuildGraph(start, leaves, usableAction, goal);

        if (!success)
        {
            Debug.LogError("No Plan");
            return null;
        }

        Node costMinPath = leaves[0];
        for (int i = 1; i < leaves.Count; i++)
        {
            if (costMinPath.cost > leaves[i].cost)
            {
                costMinPath = leaves[i];
            }
        }

        Stack<IAction> plan = new Stack<IAction>();
        while (costMinPath!=null && costMinPath.action != null)
        {
            plan.Push(costMinPath.action);
            Debug.LogWarning("actionName:"+costMinPath.action.actionName);
            costMinPath = costMinPath.parent;
        }
        return plan;
    }

    private bool BuildGraph(Node start, List<Node> leaves, List<IAction> usableAction, Dictionary<string, int> goal)
    {
        bool isFindPath = false;
        for (int i = 0; i < usableAction.Count; i++)
        {
            if (usableAction[i].IsCanInvoke(start.states))
            {
                var action = usableAction[i];
                var newStation = MergeCondition(start.states, action);
                Node node = new Node(start, start.cost + action.cost, action, newStation);
                bool isSatisfied = CheckIsSatisfiedGoal(goal, node.states);
                if (isSatisfied)
                {
                    //满足了直接返回
                    isFindPath = true;
                    leaves.Add(node);
                }
                else
                {
                    //查找子类中是否有满足的 自己已加入 所以需要剔除掉
                    List<IAction> newUsableAction = new List<IAction>(usableAction);
                    newUsableAction.RemoveAt(i);
                    isFindPath |= BuildGraph(node, leaves, newUsableAction, goal);
                }
            }
        }
        return isFindPath;
    }

    private Dictionary<string, int> MergeCondition(Dictionary<string, int> curDiction, IAction action)
    {
        Dictionary<string, int> newDiction = new Dictionary<string, int>(curDiction);
        foreach (var effect in action.afterEffect)
        {
            if (newDiction.ContainsKey(effect.key))
            {
                newDiction[effect.key] += effect.value;
            }
            else
            {
                newDiction.Add(effect.key,effect.value);
            }
            Debug.LogError("key"+effect.key);
        }

        return newDiction;
    }

    private bool CheckIsSatisfiedGoal(Dictionary<string, int> goal, Dictionary<string, int> curState)
    {
        foreach (var pair in goal)
        {
            if (!curState.ContainsKey(pair.Key) || curState[pair.Key] < pair.Value)
            {
                return false;
            }
        }
        return true;
    }
}
