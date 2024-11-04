public enum StateType
{
    GotoHospital,
    GotoDoor,
}

public static class CreateHelper
{
    public static WorldState State(StateType type)
    {
        return new (type.ToString(), 1);
    }
    
    public static WorldState State(StateType type, int num)
    {
        return new (type.ToString(), num);
    }

    public static GotoTargetAction HospitalAction(IAgent agent)
    {
        var gotoHospital = new GotoTargetAction("GoToHp", agent, 1, "WaitingArea");
        gotoHospital.AddPreCondition(State(StateType.GotoDoor));
        gotoHospital.AddEffectCondition(State(StateType.GotoHospital));
        return gotoHospital;
    }

    public static GotoTargetAction DoorAction(IAgent agent)
    {
        var gotoDoor = new GotoTargetAction("GoToDoor", agent, 1, "Door");
        gotoDoor.AddEffectCondition(CreateHelper.State(StateType.GotoDoor));
        return gotoDoor;
    }
}
