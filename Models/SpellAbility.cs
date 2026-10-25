namespace Models;

public partial class SpellAbility
{
    public override SpellAbility Copy()
    {
        return new SpellAbility
        {
            Item = Item.Copy() as OneShotEffect
        };
    }
}
