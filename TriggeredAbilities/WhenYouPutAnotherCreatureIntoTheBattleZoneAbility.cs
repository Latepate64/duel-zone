using Engine;
using Engine.Abilities;

namespace TriggeredAbilities;

public class WhenYouPutAnotherCreatureIntoTheBattleZoneAbility : WheneverCreatureIsPutIntoTheBattleZoneAbility
{
    public WhenYouPutAnotherCreatureIntoTheBattleZoneAbility(
        WhenYouPutAnotherCreatureIntoTheBattleZoneAbility ability) : base(ability)
    {
    }

    public WhenYouPutAnotherCreatureIntoTheBattleZoneAbility(IOneShotEffect effect) : base(effect)
    {
    }

    public override IAbility Copy()
    {
        return new WhenYouPutAnotherCreatureIntoTheBattleZoneAbility(this);
    }

    public override string ToString()
    {
        return $"When you put another creature into the battle zone, {GetEffectText()}";
    }

    protected override bool TriggersFrom(Creature card, IGame game)
    {
        return Source != card && Controller == card.Owner;
    }
}
