using Interfaces;

namespace OneShotEffects;

public sealed class ProtectiveForceEffect : CreatureSelectionEffect
{
    public ProtectiveForceEffect() : base(1, 1, true)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new ProtectiveForceEffect();
    }

    public override string ToString()
    {
        return "One of your creatures in the battle zone that has \"blocker\" gets +4000 power until the end of the turn.";
    }

    protected override void Apply(IGame game, IAbility source, params ICreature[] cards)
    {
        game.AddContinuousEffects(Ability, new ContinuousEffects.ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect(
            4000, cards));
    }

    protected override IEnumerable<ICreature> GetSelectableCards(IGame game, IAbility source)
    {
        return game.BattleZone.CreaturesThatHaveBlockerOwnedBy(Ability.Controller);
    }
}
