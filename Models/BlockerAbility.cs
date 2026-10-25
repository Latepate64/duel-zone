namespace Models;

public partial class BlockerAbility
{
    public override BlockerAbility Copy()
    {
        return new BlockerAbility();
    }

    public override bool Equals(object? obj)
    {
        return obj is BlockerAbility;
    }
}
