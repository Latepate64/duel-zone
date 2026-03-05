using Interfaces;
using ContinuousEffects;

namespace OneShotEffects;

public sealed class BurningPowerEffect : CreatureSelectionEffect
{
    public BurningPowerEffect() : base(1, 1, true)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new BurningPowerEffect();
    }

    public override string ToString()
    {
        return "One of your creatures gets \"power attacker +2000\" until the end of the turn.";
    }

    protected override void Apply(IGame game, IAbility source, params ICreature[] cards)
    {
        game.AddContinuousEffects(Ability, new ThisCreatureGetsPowerAttackerUntilTheEndOfTheTurnEffect(
            2000, cards));
    }

    protected override IEnumerable<ICreature> GetSelectableCards(IGame game, IAbility source)
    {
        return game.BattleZone.GetCreatures(Ability.Controller.Id);
    }
}
