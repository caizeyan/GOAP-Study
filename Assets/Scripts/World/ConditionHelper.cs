public static class ConditionHelper
{
    public static WorldState GoToHospital()
    {
        return new ("Hp", 1);
    }
    
    public static WorldState GoToDoor()
    {
        return new ("Door", 1);
    }
}
