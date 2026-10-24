namespace Models;

public partial class WhenYouPutThisCreatureIntoTheBattleZoneAbility : TriggeredAbility
{
    public override WhenYouPutThisCreatureIntoTheBattleZoneAbility Copy()
    {
        var copy = new WhenYouPutThisCreatureIntoTheBattleZoneAbility
        {
            Item = Item.Copy()
        };
        return copy;
    }
}