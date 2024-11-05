using System.Collections.Generic;

public class Nurse: IAgent
{
    protected override void InitActions()
    {
        actions.Add(new WaitingPatient(this));
        actions.Add(new GetPatient(this));
        actions.Add(new TreatPatient(this));
    }

    protected override void InitGoals()
    {
        Goal goal = new Goal("Patient");
        goal.AddStation(StateType.TreatPatient);
        goals.Add(goal);
    }
}
