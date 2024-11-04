using UnityEngine;
using UnityEngine.AI;

public class GotoTargetAction:IAction
{
    public string targetTag;
    public GameObject targetGo;
    public NavMeshAgent navAgent;

    protected override void Prepare()
    {
        if (targetGo == null)
        {
            targetGo = GameObject.FindWithTag(targetTag);
        }

        if (navAgent == null)
        {
            navAgent = agent.GetComponent<NavMeshAgent>();
        }

        if (targetGo && navAgent)
        {
            stage = ActionStage.Progress;
            navAgent.SetDestination(targetGo.transform.position);
        }
    }

    protected override void Progress()
    {
        if (navAgent.remainingDistance < 1.0f)
        {
            stage = ActionStage.Finished;
        }
    }

    public GotoTargetAction(string name, IAgent agent, int cost,string tag) : base(name, agent, cost)
    {
        this.targetTag = tag;
    }
}

