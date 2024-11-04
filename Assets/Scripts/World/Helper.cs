using System.Collections.Generic;

public static class Helper
{
    public static bool IsConditionSatisfied(Dictionary<string, int> dictionary,WorldState condition)
    {
        if (dictionary.ContainsKey(condition.key))
        {
            return dictionary[condition.key] >= condition.value;
        }

        return false;
    }
}
