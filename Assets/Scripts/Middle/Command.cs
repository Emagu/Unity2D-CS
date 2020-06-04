using UnityEngine;

public class Command : BetterToggleGroup
{
    public Unit HandlerUnit;
    protected override void OnChange(UnityEngine.UI.Toggle newactive)
    {
        HandlerUnit.SelectCommand(newactive.name);
    }
}
