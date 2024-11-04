using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class IAgent: MonoBehaviour
{
    public List<IAction> actions = new List<IAction>();
    public List<Goal> goals = new List<Goal>();
    public Stack<IAction> actionStack;
    public Goal curGoal;
    GPlan panle = new GPlan();
    private int curGoalIndex = 0;
    
    private void Awake()
    {
        curGoalIndex = 0;
        InitActions();
        InitGoals();
    }

    protected abstract void InitActions();
    protected abstract void InitGoals();

    private void Update()
    {
        if (goals.Count == 0)
        {
            return;
        }

        //判断目标是否完成
        if (curGoal == null)
        {
            curGoal = goals[0];
        }

        //没有就进行查找
        if (actionStack == null)
        {
            actionStack = panle.GetPlan(actions, curGoal.sgoals);
        }

        //对当前队列进行运行
        if (actionStack != null && actionStack.Count > 0)
        {
            if (actionStack.Peek().Run() == ActionStage.Finished)
            {
                actionStack.Pop();
                //处理完成
                if (actionStack.Count == 0)
                {
                    goals.RemoveAt(0);
                    actionStack = null;
                }
            }
        }
      
    }
}
