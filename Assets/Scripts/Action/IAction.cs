using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum ActionStage
{
    Prepare,
    Progress,
    Finished
}

public abstract class IAction 
{
    public float cost = 1f;
    public List<WorldState> preConditions;
    public List<WorldState> afterEffects;
    private GWorld world =  GWorld.Instance;
    public string actionName = "";
    public ActionStage stage = ActionStage.Prepare;
    public IAgent agent;

    public IAction(string name, IAgent agent,int cost)
    {
        this.actionName = name;
        this.agent = agent;
        this.cost = cost;
        stage = ActionStage.Prepare;
        preConditions = new List<WorldState>();
        afterEffects = new List<WorldState>();
    }

    public void AddPreCondition(WorldState preCondition)
    {
        preConditions.Add(preCondition);
    }

    public void AddEffectCondition(WorldState afterEffect)
    {
        this.afterEffects.Add(afterEffect);
    }
    
    //当前场景是否可以使用该Action
    public bool IsValuable()
    {
        //return IsValuable(world.GetStates());
        return true;
    }
    
    //是否满足路径
    public bool IsCanInvoke(Dictionary<string, int> dictionary)
    {
        if (preConditions != null)
        {
            //判断前提条件
            foreach (var condition in preConditions)
            {
                if (!Helper.IsConditionSatisfied(dictionary,condition))
                {
                    return false;
                }
            }
        }
        return true;
    }
 

    protected virtual void Prepare()
    {
        stage = ActionStage.Progress;
    }

    protected virtual void Progress()
    {
        stage = ActionStage.Finished;
    }
    
    protected virtual void Finish()
    {
    }


    public ActionStage Run()
    {
        //当前刷新state后需要下一帧才执行对应方法
        var preState = stage;
        if (stage == ActionStage.Prepare)
        {
            Prepare();
        }
        else if (stage == ActionStage.Progress)
        {
            Progress();
        }
        else if (stage == ActionStage.Finished)
        {
            Finish();
        }
        return preState;
    }
    
}


