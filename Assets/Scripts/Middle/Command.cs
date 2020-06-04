public class Command : BetterToggleGroup
{
    public Object HandlerUnit;
    protected override void OnChange(UnityEngine.UI.Toggle newactive)
    {
        HandlerUnit.SelectCommand(newactive.name);
    }
}
