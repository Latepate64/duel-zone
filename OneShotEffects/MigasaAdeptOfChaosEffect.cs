using OneShotEffects;
using Engine.Abilities;
using System.Collections.Generic;
using ContinuousEffects;
using Interfaces;

namespace OneShotEffects;

public sealed class MigasaAdeptOfChaosEffect : CreatureSelectionEffect
{
    public MigasaAdeptOfChaosEffect() : base(1, 1, true)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new MigasaAdeptOfChaosEffect();
    }

    public override string ToString()
    {
        return "One of your fire creatures in the battle zone gets \"double breaker\" until the end of the turn.";
    }

    protected override void Apply(IGame game, IAbility source, params ICreature[] cards)
    {
        game.AddContinuousEffects(Ability, new ThisCreatureGetsAbilityUntilTheEndOfTheTurnEffect(
            new StaticAbility(new DoubleBreakerEffect()), cards));
    }

    protected override IEnumerable<ICreature> GetSelectableCards(IGame game, IAbility source)
    {
        return game.BattleZone.GetCreatures(Ability.Controller.Id, Civilization.Fire);
    }
}
