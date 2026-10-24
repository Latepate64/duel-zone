namespace Models;

public partial class ResolvableAbility
{
    public override bool Equals(object? obj)
    {
        if (obj is not ResolvableAbility ability) return false;
        if (!Item.Equals(ability.Item)) return false;
        return true;
    }
}
