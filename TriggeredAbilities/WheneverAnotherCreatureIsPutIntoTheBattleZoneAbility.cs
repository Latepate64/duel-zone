using Engine;
using Engine.Abilities;

namespace TriggeredAbilities;

public class WheneverAnotherCreatureIsPutIntoTheBattleZoneAbility : WheneverCreatureIsPutIntoTheBattleZoneAbility
{
    public WheneverAnotherCreatureIsPutIntoTheBattleZoneAbility(
        WheneverAnotherCreatureIsPutIntoTheBattleZoneAbility ability) : base(ability)
    {
    }

    public WheneverAnotherCreatureIsPutIntoTheBattleZoneAbility(IOneShotEffect effect) : base(effect)
    {
    }

    public override IAbility Copy()
    {
        return new WheneverAnotherCreatureIsPutIntoTheBattleZoneAbility(this);
    }

    public override string ToString()
    {
        return $"Whenever another creature is put into the battle zone, {GetEffectText()}";
    }

    protected override bool TriggersFrom(ICreature card, IGame game)
    {
        return Source != card;
    }
}
