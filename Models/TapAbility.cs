namespace Models;

public partial class TapAbility
{
    public override TapAbility Copy()
    {
        return new TapAbility
        {
            Item = Item.Copy() as OneShotEffect
        };
    }
}
