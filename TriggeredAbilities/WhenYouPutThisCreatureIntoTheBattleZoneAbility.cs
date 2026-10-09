using Interfaces;

namespace TriggeredAbilities;

/// <summary>
/// When you put this creature into the battle zone
/// </summary>
public class WhenYouPutThisCreatureIntoTheBattleZoneAbility
    : WheneverCreatureIsPutIntoTheBattleZoneAbility
{
    public WhenYouPutThisCreatureIntoTheBattleZoneAbility(
        IOneShotEffect effect) : base(effect)
    {
    }

    public WhenYouPutThisCreatureIntoTheBattleZoneAbility(
        WhenYouPutThisCreatureIntoTheBattleZoneAbility ability) : base(ability)
    {
    }

    public override IAbility Copy()
    {
        return new WhenYouPutThisCreatureIntoTheBattleZoneAbility(this);
    }

    protected override bool TriggersFrom(ICreature card, IGame game)
    {
        return Source == card;
    }
}
