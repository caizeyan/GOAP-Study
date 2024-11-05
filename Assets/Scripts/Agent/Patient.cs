using System.Collections.Generic;

public class Patient: IAgent
{
    protected override void InitActions()
    {
        List<IAction> list = new List<IAction>();
        actions.Add(new GotoDoorAction(this));
        actions.Add(new GotoWaitingRoomAction(this));
        actions.Add(new GotoCubicle(this));
        actions.Add(new GotoHome(this));
    }

    protected override void InitGoals()
    {
        Goal goal = new Goal("Patient");
        goal.AddStation(StateType.GotoWaitingRoom);
        
        Goal goal1 = new Goal("Patient");
        goal.AddStation(StateType.GoHome);
        
        goals.Add(goal);
        
    }
}
