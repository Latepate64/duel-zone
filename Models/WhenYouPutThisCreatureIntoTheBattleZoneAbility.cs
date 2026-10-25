namespace Models;

public partial class WhenYouPutThisCreatureIntoTheBattleZoneAbility
{
    public override WhenYouPutThisCreatureIntoTheBattleZoneAbility Copy()
    {
        var copy = new WhenYouPutThisCreatureIntoTheBattleZoneAbility
        {
            Item = Item.Copy() as OneShotEffect
        };
        return copy;
    }
}