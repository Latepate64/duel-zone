using Engine.Abilities;
using Interfaces;

namespace TriggeredAbilities;

public class WheneverYouPutDragonoidOrDragonIntoTheBattleZoneAbility : WheneverCreatureIsPutIntoTheBattleZoneAbility
{
    public WheneverYouPutDragonoidOrDragonIntoTheBattleZoneAbility(
        WheneverYouPutDragonoidOrDragonIntoTheBattleZoneAbility ability) : base(ability)
    {
    }

    public WheneverYouPutDragonoidOrDragonIntoTheBattleZoneAbility(IOneShotEffect effect) : base(effect)
    {
    }

    public override IAbility Copy()
    {
        return new WheneverYouPutDragonoidOrDragonIntoTheBattleZoneAbility(this);
    }

    public override string ToString()
    {
        return $"Whenever you put a Dragonoid or a creature that has Dragon in its race into the battle zone, {GetEffectText()}";
    }

    protected override bool TriggersFrom(ICreature card, IGame game)
    {
        return Controller == card.Owner && (card.HasRace(Race.Dragonoid) || card.IsDragon);
    }
}
