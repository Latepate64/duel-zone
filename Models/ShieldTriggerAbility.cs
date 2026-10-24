namespace Models;

public partial class ShieldTriggerAbility
{
    public override ShieldTriggerAbility Copy()
    {
        return new ShieldTriggerAbility();
    }

    public override bool Equals(object? obj)
    {
        return obj is ShieldTriggerAbility;
    }
}
