using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class IAgent: MonoBehaviour
{
    public List<IAction> actions = new List<IAction>();
    public Dictionary<Goal, int> goles = new Dictionary<Goal, int>();

    IPlan panle;
    public Queue<IAction> actionQueue;
    public IAction curAction;
    public Goal curGoal;
    private void Awake()
    {
        InitActions();
        InitGoals();
    }

    protected abstract void InitActions();
    protected abstract void InitGoals();
}
