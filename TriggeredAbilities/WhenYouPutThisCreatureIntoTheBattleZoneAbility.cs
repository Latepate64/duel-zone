using Interfaces;

namespace TriggeredAbilities;

public class WhenYouPutThisCreatureIntoTheBattleZoneAbility : WheneverCreatureIsPutIntoTheBattleZoneAbility
{
    public WhenYouPutThisCreatureIntoTheBattleZoneAbility(IOneShotEffect effect) : base(effect)
    {
    }

    public WhenYouPutThisCreatureIntoTheBattleZoneAbility(WhenYouPutThisCreatureIntoTheBattleZoneAbility ability) :
        base(ability)
    {
    }

    public override IAbility Copy()
    {
        return new WhenYouPutThisCreatureIntoTheBattleZoneAbility(this);
    }

    public override string ToString()
    {
        return $"When you put this creature into the battle zone, {GetEffectText()}";
    }

    protected override bool TriggersFrom(ICreature card, IGame game)
    {
        return Source == card;
    }
}
